# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000

# Set environment variables
ENV ASPNETCORE_URLS=http://*:5000

# Use the SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["teamtrack-api/teamtrack-api.csproj", "./teamtrack-api/"]
RUN dotnet restore "./teamtrack-api/teamtrack-api.csproj"
COPY . .
WORKDIR "/src/teamtrack-api"
RUN dotnet build "teamtrack-api.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "teamtrack-api.csproj" -c Release -o /app/publish -p:UseAppHost=false

# Use the runtime image to run the project
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "teamtrack-api.dll"]