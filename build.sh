#!/bin/bash
rm -r ./publish
set -e
dotnet restore
dotnet build
dotnet publish -o ../publish -c Release
docker build -t face-recognition .