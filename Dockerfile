FROM mcr.microsoft.com/dotnet/aspnet:3.1-buster-slim

WORKDIR /app

COPY bin/release/netcoreapp3.1/publish .

ENTRYPOINT dotnet dotnet-http-request.dll