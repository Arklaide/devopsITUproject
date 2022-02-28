#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MinitweetApi/MinitweetApi.csproj", "MinitweetApi/"]
RUN dotnet restore "MinitweetApi/MinitweetApi.csproj"
COPY . .
WORKDIR "/src/MinitweetApi"
RUN dotnet build "MinitweetApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinitweetApi.csproj" -c Release -o /app/publish

FROM base AS final
RUN --mount=type=secret,id=ConnectionStrings__myDb1 ls -la /run/secrets
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinitweetApi.dll"]