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
    docker run --name numpysolve_container numpysolve
    docker cp numpysolve_container:/app/data ./
    docker cp numpysolve_container:/app/resources ./
    docker rm numpysolve_container
)

echo All benchmarks completed. Results saved to %RESULTS_DIR%

python processData.py
echo Data processed

pause
