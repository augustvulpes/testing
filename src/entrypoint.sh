#!/bin/bash
dotnet test
ls bin/Release/net8.0
docker cp libapp-app-1:/app/bin/Release/net8.0/allure-results ./