# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /tmp

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /tmp
RUN dotnet publish -c release -o /out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /out
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "sge.dll"]