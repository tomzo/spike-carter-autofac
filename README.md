# spike-carter-autofac

Build with
```
./build.sh
```
Which actually runs
```
dotnet restore
dotnet publish -c Release
dotnet test tests/MyTests/MyTests.csproj
```

### Demo

Run server with
```
dotnet run -p src/Lib/MyCarterApp.csproj
```
Then use curl to interact with it
```
ide@f568b1cbcd84(mono-gide):/$ curl -i localhost:8080/employee/list
HTTP/1.1 200 OK
Date: Sun, 17 Mar 2019 16:18:03 GMT
Content-Type: application/json; charset=utf-8
Server: Kestrel
Transfer-Encoding: chunked

[{"name":"Demo"}]
```

# References
 * How to setup Autofac as DI ASP.NET Core https://github.com/autofac/Autofac.Extensions.DependencyInjection/tree/v4.3.1
 * Using carter https://github.com/CarterCommunity/Carter/tree/3.8.0