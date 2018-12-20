/// Provides a nicer interop for configuring and starting the Kestrel server.
module KestrelInterop

open Freya.Core
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Autofac.Extensions.DependencyInjection
open Autofac
open MyCarterApp

module ApplicationBuilder =
    let inline useFreya f (app:IApplicationBuilder)=
        let owin : OwinMidFunc = OwinMidFunc.ofFreya f
        app.UseOwin(fun p -> p.Invoke owin)

module WebHost =
    let create () = WebHostBuilder().UseKestrel()
    let bindTo urls (b:IWebHostBuilder) = b.UseUrls urls
    let configureServices (f: Autofac.ContainerBuilder -> unit) (s: IServiceCollection) =
        ServiceCollectionExtensions.AddAutofac(s, System.Action<Autofac.ContainerBuilder> (f)) |> ignore
        MyCarterApp.Startup.ConfigureServices(s)
        
    let configure (f : IApplicationBuilder -> IApplicationBuilder) (b:IWebHostBuilder) =
        let configureContainer (builder: Autofac.ContainerBuilder)  =
            builder.RegisterModule(new MyAutofacModule()) |> ignore
        b.ConfigureServices(System.Action<_>(configureServices configureContainer)) |> ignore
        b.Configure (System.Action<_> (f >> ignore))
        //b.UseStartup<MyCarterApp.Startup>() // this works for carter alone
    let build (b:IWebHostBuilder) = b.Build()
    let run (wh:IWebHost) = wh.Run()
    let buildAndRun : IWebHostBuilder -> unit = build >> run
