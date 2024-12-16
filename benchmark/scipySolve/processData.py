import pandas as pd
import os

# Папка, где находятся результаты (замените на вашу папку)
DATA_DIR = "data"
RESOURCES_DIR = "resources"

# Список всех CSV-файлов в папке
csv_files = [os.path.join(DATA_DIR, f) for f in os.listdir(DATA_DIR) if f.endswith('.csv')]
res_files = [os.path.join(RESOURCES_DIR, f) for f in os.listdir(RESOURCES_DIR) if f.endswith('.csv')]

# Объединение всех файлов в один DataFrame
dataframes = []
for file in csv_files:
    try:
        df = pd.read_csv(file)
        dataframes.append(df)
    except Exception as e:
        print(f"Error reading {file}: {e}")

# Объединение всех данных
all_data = pd.concat(dataframes, ignore_index=True)

# Группировка по размеру матрицы и вычисление среднего времени
average_times = all_data.groupby("matrix_size")["time"].min().reset_index()

# Сохранение среднего времени в новый CSV-файл
output_file = "scipySolve_average.csv"
average_times.to_csv(output_file, index=False)

print(f"Processed data saved to {output_file}")

# Объединение всех файлов в один DataFrame
dataframes_res = []
for file in res_files:
    try:
        df = pd.read_csv(file)
        dataframes_res.append(df)
    except Exception as e:
        print(f"Error reading {file}: {e}")

# Объединение всех данных
res_data = pd.concat(dataframes_res, ignore_index=True)

# Группировка по размеру матрицы и вычисление среднего времени
average_res = res_data.groupby("timestamp").median().reset_index()

# Сохранение среднего времени в новый CSV-файл
output_file_res = "res_average.csv"
average_res.to_csv(output_file_res, index=False)

print(f"Processed data saved to {output_file_res}")
