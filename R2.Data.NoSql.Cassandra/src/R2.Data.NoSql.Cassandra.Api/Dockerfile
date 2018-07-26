FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/R2.Data.NoSql.Cassandra.Api/R2.Data.NoSql.Cassandra.Api.csproj src/R2.Data.NoSql.Cassandra.Api/
RUN dotnet restore src/R2.Data.NoSql.Cassandra.Api/R2.Data.NoSql.Cassandra.Api.csproj
COPY . .
WORKDIR /src/src/R2.Data.NoSql.Cassandra.Api
RUN dotnet build R2.Data.NoSql.Cassandra.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish R2.Data.NoSql.Cassandra.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "R2.Data.NoSql.Cassandra.Api.dll"]
