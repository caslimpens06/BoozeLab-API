# Start with the .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

# Copy the project file and restore dependencies
COPY ["TruthOrDrinkAPI.csproj", "./"]
RUN dotnet restore "TruthOrDrinkAPI.csproj"

# Copy the remaining app files
COPY . .

# Publish the app to /app directory
RUN dotnet publish "TruthOrDrinkAPI.csproj" -c Release -o /app

# Use a smaller runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app .

# Expose the port the app runs on
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "TruthOrDrinkAPI.dll"]
