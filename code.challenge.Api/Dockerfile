#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["code.challenge.Api/code.challenge.Api.csproj", "code.challenge.Api/"]
COPY ["code.challenge.Repository/code.challenge.Repository.csproj", "code.challenge.Repository/"]
COPY ["code.challenge.Core/code.challenge.Core.csproj", "code.challenge.Core/"]
COPY ["code.challenge.Service/code.challenge.Service.csproj", "code.challenge.Service/"]
RUN dotnet restore "code.challenge.Api/code.challenge.Api.csproj"
COPY . .
WORKDIR "/src/code.challenge.Api"
RUN dotnet build "code.challenge.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "code.challenge.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "code.challenge.Api.dll"]