#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore
COPY . ./
RUN dotnet publish -c release -o /app
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build  /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "BookManager.dll"]