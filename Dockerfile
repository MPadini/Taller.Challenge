FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
# COPY DockerTest/*.csproj ./DockerTest/
COPY code.challenge.Api/*.csproj ./code.challenge.Api/
COPY code.challenge.Service/*.csproj ./code.challenge.Service/
COPY code.challenge.Core/*.csproj ./code.challenge.Core/
COPY code.challenge.UnitTests/*.csproj ./code.challenge.UnitTests/
COPY code.challenge.IntegrationTests/*.csproj ./code.challenge.IntegrationTests/
COPY SolutionItems/. ./SolutionItems/

RUN dotnet restore *.sln

# copy everything else and build app
COPY code.challenge.Api/. ./code.challenge.Api/
COPY code.challenge.Service/. ./code.challenge.Service/
COPY code.challenge.Core/. ./code.challenge.Core/
COPY code.challenge.UnitTests/. ./code.challenge.UnitTests/
COPY code.challenge.IntegrationTests/. ./code.challenge.IntegrationTests/

WORKDIR /app/code.challenge.Api
RUN dotnet publish -c Release -o /release

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime

WORKDIR /app

COPY --from=build /release ./   
ENTRYPOINT ["dotnet", "code.challenge.Api.dll"]