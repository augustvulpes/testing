import psutil
import time
import csv
import subprocess

def monitor_resources(pid, output_csv, interval, duration):
    """
    Отслеживает использование ресурсов процесса и сохраняет данные в CSV.

    :param pid: ID процесса, за которым нужно наблюдать.
    :param output_csv: Имя CSV-файла для сохранения данных.
    :param interval: Интервал между замерами (в секундах).
    :param duration: Общая продолжительность мониторинга (в секундах).
    """
    process = psutil.Process(pid)
    
    # Открываем CSV-файл для записи
    with open(output_csv, "w", newline="") as csvfile:
        fieldnames = ["timestamp", "cpu_percent", "memory_percent", "read_bytes", "write_bytes"]
        writer = csv.DictWriter(csvfile, fieldnames=fieldnames)
        writer.writeheader()

        start_time = time.time()
        while time.time() - start_time < duration:
            if not psutil.pid_exists(pid):  # Если процесс завершился
                break

            # Снимаем метрики
            timestamp = time.time() - start_time

            cpu_percent = process.cpu_percent(interval=None)
            memory_percent = process.memory_percent()
            io_counters = process.io_counters()

            if not timestamp:
                continue

            # if (timestamp and not cpu_percent and not memory_percent):
            #     break

            writer.writerow({
                "timestamp": round(timestamp, 2),
                "cpu_percent": cpu_percent,
                "memory_percent": memory_percent,
                "read_bytes": io_counters.read_bytes,
                "write_bytes": io_counters.write_bytes
            })

            time.sleep(interval)

# Пример использования
if __name__ == "__main__":
    # Запускаем тестовый процесс
    process = subprocess.Popen(["python", "numpySolve.py"])
    pid = process.pid

    # Запускаем мониторинг ресурсов
    monitor_resources(pid, output_csv=f"./resources/resource_usage_{int(time.time())}.csv", interval=0.1, duration=3)

    # Дожидаемся завершения процесса
    process.wait()
