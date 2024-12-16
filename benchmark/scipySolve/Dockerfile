# Dockerfile для тестирования NumPy и SciPy
FROM python:3.10-slim

# Установка необходимых библиотек
RUN pip install numpy scipy pandas psutil

# Копируем скрипт для тестирования
WORKDIR /app
COPY scipySolve.py .
COPY runTest.py .

RUN mkdir -p data
RUN mkdir -p resources

# Команда запуска скрипта
CMD ["python", "runTest.py"]
