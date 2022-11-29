#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal-arm64v8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal-arm64v8 AS build
WORKDIR /src
COPY ["BlazorSite2/Server/BlazorSite2.Server.csproj", "BlazorSite2/Server/"]
COPY ["BlazorSite2/Client/BlazorSite2.Client.csproj", "BlazorSite2/Client/"]
COPY ["BlazorSite2/Shared/BlazorSite2.Shared.csproj", "BlazorSite2/Shared/"]
RUN dotnet restore "BlazorSite2/Server/BlazorSite2.Server.csproj"
COPY . .
WORKDIR "/src/BlazorSite2/Server"
RUN dotnet build "BlazorSite2.Server.csproj" -c Release -o /app/build -r linux-arm64

FROM build AS publish
RUN dotnet publish "BlazorSite2.Server.csproj" -c Release -o /app/publish -r linux-arm64

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["BlazorSite2/Server/raw.svg", "/app/"]
ENTRYPOINT ["dotnet", "BlazorSite2.Server.dll"]