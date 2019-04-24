FROM microsoft/dotnet:2.2-sdk AS build-env

LABEL version="1.0.0" mainteiner="Gianclaudio"

WORKDIR /app

COPY ./DockerNetCoreExample/dist .

ENTRYPOINT ["dotnet", "DockerNetCoreExample.dll"]