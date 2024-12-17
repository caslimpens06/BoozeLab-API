# Start with the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

# Copy the project file and restore dependencies
# The csproj file is inside the 'TruthOrDrinkAPI' folder
COPY TruthOrDrinkAPI/TruthOrDrinkAPI.csproj ./TruthOrDrinkAPI/

# Navigate to the project folder
WORKDIR /src/TruthOrDrinkAPI

RUN dotnet restore

# Copy the remaining app files
COPY . .

# Publish the app to /app directory
RUN dotnet publish -c Release -o /app

# Use a smaller runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app .

# Expose the port the app runs on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "TruthOrDrinkAPI.dll"]
