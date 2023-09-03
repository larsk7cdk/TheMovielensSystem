FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SAiP3.API/SAiP3.API.csproj", "SAiP3.API/"]
RUN dotnet restore "SAiP3.API/SAiP3.API.csproj"
COPY . .
WORKDIR "/src/SAiP3.API"
RUN dotnet build "SAiP3.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SAiP3.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SAiP3.API.dll"]
