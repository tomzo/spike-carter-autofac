module Program

open KestrelInterop

[<EntryPoint>]
let main _ =
  let configureApp =
    ApplicationBuilder.useFreya Api.root

  WebHost.create ()
  |> WebHost.bindTo [|"http://localhost:5000"|]
  |> WebHost.configure configureApp
  |> WebHost.buildAndRun

  0
