#!/bin/bash -e

paket restore
dotnet restore
dotnet publish -c Release
dotnet packages/build/xunit.runner.console/tools/netcoreapp2.0/xunit.console.dll tests/MyTests/bin/Release/netcoreapp2.1/publish/MyTests.dll
