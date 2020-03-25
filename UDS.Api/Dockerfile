#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["UDS.Api/UDS.Api.csproj", "UDS.Api/"]
COPY ["UDS.Data/UDS.Data.csproj", "UDS.Data/"]
COPY ["UDS.Business/UDS.Business.csproj", "UDS.Business/"]
RUN dotnet restore "UDS.Api/UDS.Api.csproj"
COPY . .
WORKDIR "/src/UDS.Api"
RUN dotnet build "UDS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UDS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UDS.Api.dll"]
