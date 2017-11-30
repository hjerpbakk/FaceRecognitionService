#!/bin/bash
rm -r ./publish
set -e
dotnet publish -o ../publish -c Release
docker build -t face-recognition .