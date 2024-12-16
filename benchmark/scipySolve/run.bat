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
    docker run --name scipysolve_container scipysolve
    docker cp scipysolve_container:/app/data ./
    docker cp scipysolve_container:/app/resources ./
    docker rm scipysolve_container
)

echo All benchmarks completed. Results saved to %RESULTS_DIR%

python processData.py
echo Data processed

pause
