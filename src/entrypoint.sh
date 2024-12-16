#!/bin/bash
#sh -c ./ndepend/NDepend.Console.Core ./LibraryApp.ndproj /OutDir ndepend-output && grep -q 'Error' ndepend-output/NDependAnalysisResult.xml

dotnet test LibraryApp.csproj -- RunConfiguration.ReporterSwitch=allure
ls
ls bin/
ls bin/Debug/
ls bin/Debug/net8.0
ls bin/Debug/net8.0/allure-results
# ls bin/Release/
# ls bin/Release/net8.0
# ls bin/Release/net8.0/allure-results