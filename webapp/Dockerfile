# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /tmp

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /tmp
ENV ASPNETCORE_ENVIRONMENT Development
RUN dotnet publish -c release -o /out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /out
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "webapp.dll"]