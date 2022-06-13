FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LookupApi/LookupApi.csproj", "LookupApi/"]
RUN dotnet restore "LookupApi/LookupApi.csproj"
COPY . .
WORKDIR "/src/LookupApi"
RUN dotnet build "LookupApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LookupApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LookupApi.dll"]
