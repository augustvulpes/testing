# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS test-env

# Устанавливаем рабочую директорию
WORKDIR /app
EXPOSE 5000

# Копируем .csproj файл и устанавливаем зависимости
COPY ./src .
# RUN dotnet add package Allure.Xunit
# RUN dotnet restore
RUN dotnet add LibraryApp.csproj package Allure.Xunit
RUN dotnet build LibraryApp.csproj

ENTRYPOINT ["dotnet", "test", "LibraryApp.csproj"]
# RUN ["chmod", "+x", "./entrypoint.sh"]
# # Запускаем тесты
# ENTRYPOINT ["./entrypoint.sh"]