#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MinitwitFrontend.csproj", "."]
RUN dotnet restore "./MinitwitFrontend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MinitwitFrontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinitwitFrontend.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf