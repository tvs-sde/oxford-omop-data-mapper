#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release_no_docs
WORKDIR /src
COPY . .
RUN dotnet restore ./OmopTransformer.sln
COPY . .
WORKDIR /src
RUN dotnet build OmopTransformer.sln -c $BUILD_CONFIGURATION -o /app/build
RUN dotnet test OmopTransformer.sln -c $BUILD_CONFIGURATION -o /app/build
FROM build AS publish
ARG BUILD_CONFIGURATION=Release_no_docs
RUN dotnet publish "OmopTransformer/OmopTransformer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "omop.dll"]