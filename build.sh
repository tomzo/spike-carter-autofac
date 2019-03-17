#!/bin/bash -e

dotnet restore
dotnet publish -c Release
dotnet test tests/MyTests/MyTests.csproj
