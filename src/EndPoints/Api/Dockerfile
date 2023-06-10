#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/EndPoints/Api/Api.csproj", "src/EndPoints/Api/"]
COPY ["src/Core/Application/Application.csproj", "src/Core/Application/"]
COPY ["src/Infrastructure/Network/Network.csproj", "src/Infrastructure/Network/"]
COPY ["src/Infrastructure/Persistence/Persistence.csproj", "src/Infrastructure/Persistence/"]
COPY ["src/Core/Domain/Domain.csproj", "src/Core/Domain/"]
COPY ["src/Shared/Utitlity/Utility.csproj", "src/Shared/Utitlity/"]
COPY ["src/Infrastructure/Network.Grpc/Network.Grpc.csproj", "src/Infrastructure/Network.Grpc/"]
COPY ["src/Infrastructure/Persistence.Mongo/Persistence.Mongo.csproj", "src/Infrastructure/Persistence.Mongo/"]
RUN dotnet restore "src/EndPoints/Api/Api.csproj"
COPY . .
WORKDIR "/src/src/EndPoints/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]