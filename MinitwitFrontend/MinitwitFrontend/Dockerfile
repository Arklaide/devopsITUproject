#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MinitwitFrontend/MinitwitFrontend/MinitwitFrontend.csproj", "MinitwitFrontend/MinitwitFrontend/"]
RUN dotnet restore "MinitwitFrontend/MinitwitFrontend/MinitwitFrontend.csproj"
COPY . .
WORKDIR "/src/MinitwitFrontend/MinitwitFrontend"
RUN dotnet build "MinitwitFrontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MinitwitFrontend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MinitwitFrontend.dll"]