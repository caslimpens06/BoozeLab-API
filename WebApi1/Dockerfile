# Use .NET 8.0 SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy the project file and restore dependencies
COPY ["WebApi1/RenderDrinkAPI.csproj", "WebApi1/"]
RUN dotnet restore "WebApi1/RenderDrinkAPI.csproj"

# Copy the remaining app files
COPY . .

# Publish the app to /app directory
RUN dotnet publish "WebApi1/RenderDrinkAPI.csproj" -c Release -o /app

# Use .NET 8.0 runtime to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app .

# Expose the port the app runs on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "RenderDrinkAPI.dll"]
