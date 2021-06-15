#!/bin/sh

dotnet build Common/MagicOnionCommon.csproj
cp Common/bin/Debug/netstandard2.0/MagicOnionCommon.dll Client/MagicOnionTest/Assets/Binary
dotnet publish Server/MagicOnionServer.csproj -r osx.10.11-x64
Server/bin/Debug/netcoreapp3.1/osx.10.11-x64/publish/MagicOnionServer
