@echo off
REM Папка для сохранения результатов
set RESULTS_DIR=data

REM Создание папки, если она не существует
if not exist "%RESULTS_DIR%" (
    mkdir "%RESULTS_DIR%"
)

REM Цикл запуска контейнера 100 раз
for /L %%i in (1,1,100) do (
    echo Running container %%i...
    @REM docker run --rm -v "%cd%\%RESULTS_DIR%:/" numpyinv
    docker run --name numpyinv_container numpyinv
    docker cp numpyinv_container:/app/data ./
    docker cp numpyinv_container:/app/resources ./
    docker rm numpyinv_container
)

echo All benchmarks completed. Results saved to %RESULTS_DIR%

python processData.py
echo Data processed

pause
