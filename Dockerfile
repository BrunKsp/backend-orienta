FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Orienta.API/Orienta.API.csproj", "src/Orienta.API/"]
RUN dotnet restore "src/Orienta.API/Orienta.API.csproj" 
COPY . .
WORKDIR "/src/src/Orienta.API"
RUN dotnet build "Orienta.API.csproj" -c Release -o /app/build 

FROM build AS publish
RUN dotnet publish "Orienta.API.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet api.dll
