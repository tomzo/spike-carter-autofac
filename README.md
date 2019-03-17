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

# References
 * How to setup Autofac as DI ASP.NET Core https://github.com/autofac/Autofac.Extensions.DependencyInjection/tree/v4.3.1
 * Using carter https://github.com/CarterCommunity/Carter/tree/3.8.0