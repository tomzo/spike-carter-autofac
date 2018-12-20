module Program

open KestrelInterop

[<EntryPoint>]
let main _ =
  //let webHostBuilder = 
  WebHost.create ()
  //MyCarterApp.WebHostBuilderExtensions.ConfigureWebHostBuilder(webHostBuilder)
  |> WebHost.configure ApplicationBuilder.configureApp
  |> WebHost.bindTo [|"http://localhost:5000"|]
  |> WebHost.buildAndRun

  0
