#!/bin/bash
dotnet test -- RunConfiguration.ReporterSwitch=allure
ls
ls bin/
ls bin/Release/
ls bin/Release/net8.0
ls bin/Release/net8.0/allure-results