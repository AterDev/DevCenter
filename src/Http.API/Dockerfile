#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Http.API/Http.API.csproj", "src/Http.API/"]
COPY ["src/Http.Application/Http.Application.csproj", "src/Http.Application/"]
COPY ["src/Share/Share.csproj", "src/Share/"]
COPY ["src/Core/Core.csproj", "src/Core/"]
COPY ["src/Database/EntityFramework/EntityFramework.csproj", "src/Database/EntityFramework/"]
RUN dotnet restore "src/Http.API/Http.API.csproj"
COPY . .
WORKDIR "/src/src/Http.API"
RUN dotnet build "Http.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Http.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Http.API.dll"]