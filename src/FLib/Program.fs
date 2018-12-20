module Program

open KestrelInterop

[<EntryPoint>]
let main _ =
  let configureApp appBuilder =
    ApplicationBuilder.useFreya Api.root appBuilder
    |> MyCarterApp.Startup.ConfigureCarter
    appBuilder

  let webHostBuilder = WebHost.create ()
  MyCarterApp.WebHostBuilderExtensions.ConfigureWebHostBuilder(webHostBuilder)
  |> WebHost.bindTo [|"http://localhost:5000"|]
  |> WebHost.configure configureApp
  |> WebHost.buildAndRun

  0
