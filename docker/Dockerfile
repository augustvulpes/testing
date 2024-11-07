# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS test-env

# Set working directory inside the container
WORKDIR /app

# Copy everything to the container
COPY . .

# Restore dependencies and build the project
RUN dotnet restore
RUN dotnet build --no-restore

# Run tests
CMD ["dotnet", "test", "--no-build"]