# Use the official .NET 8 SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy all files and build the app
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Build runtime image (lighter version)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Render uses port 8080 by default
EXPOSE 8080

# Start your Web API
ENTRYPOINT ["dotnet", "MyGhar_Backend.dll"]
