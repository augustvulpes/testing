import numpy as np
import scipy.linalg
import pandas as pd
from time import time, perf_counter

def measure_time(func, *args, **kwargs):
    start_time = perf_counter()
    func(*args, **kwargs)
    end_time = perf_counter()
    return end_time - start_time

# Параметры эксперимента
matrix_sizes = [i for i in range(10, 201, 10)]  # Размеры матриц для тестирования
repeats = 5  # Количество повторений для каждой операции

# Для хранения результатов
results_numpy_inv = []

# Проведение замеров
for size in matrix_sizes:
    for _ in range(repeats):
        # Генерация случайной квадратной матрицы и вектора
        A = np.random.rand(size, size)
        b = np.random.rand(size)

        time_scipy_solve = measure_time(scipy.linalg.solve, A, b)
        results_numpy_inv.append({"matrix_size": size, "time": time_scipy_solve})

# Сохранение результатов в CSV-файлы
pd.DataFrame(results_numpy_inv).to_csv(f"./data/scipy_solve_{int(time())}.csv", index=False)
