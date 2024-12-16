import pandas as pd
import matplotlib.pyplot as plt

# Загрузка данных из CSV-файлов
numpy_inv_data = pd.read_csv('./numpyInv/numpyInv_average.csv')
numpy_inv_res = pd.read_csv('./numpyInv/res_average.csv')
scipy_inv_data = pd.read_csv('./scipyInv/scipyInv_average.csv')
scipy_inv_res = pd.read_csv('./scipyInv/res_average.csv')
numpy_solve_data = pd.read_csv('./numpySolve/numpySolve_average.csv')
numpy_solve_res = pd.read_csv('./numpySolve/res_average.csv')
scipy_solve_data = pd.read_csv('./scipySolve/scipySolve_average.csv')
scipy_solve_res = pd.read_csv('./scipySolve/res_average.csv')

numpy_inv = numpy_inv_data.sort_values("matrix_size")
scipy_inv = scipy_inv_data.sort_values("matrix_size")
numpy_solve = numpy_solve_data.sort_values("matrix_size")
scipy_solve = scipy_solve_data.sort_values("matrix_size")

# Создание фигуры и двух графиков
fig, axes = plt.subplots(2, 4, figsize=(12, 10))

# === График 1: Нахождение обратной матрицы ===
axes[0][0].plot(numpy_inv["matrix_size"], numpy_inv["time"], label="NumPy", marker="o", color="b")
axes[0][0].plot(scipy_inv["matrix_size"], scipy_inv["time"], label="SciPy", marker="o", color="r")
#axes[0].plot(scipy_inv_avg.index, scipy_inv_avg.values, label="SciPy", marker="s", color="r")
axes[0][0].set_title("Нахождение обратной матрицы")
axes[0][0].set_xlabel("Размер матрицы")
axes[0][0].set_ylabel("Время (секунды)")
axes[0][0].legend()
axes[0][0].grid()

axes[0][1].plot(numpy_inv_res["timestamp"], numpy_inv_res["cpu_percent"], label="Numpy", color="blue")
axes[0][1].plot(scipy_inv_res["timestamp"], scipy_inv_res["cpu_percent"], label="Scipy", color="red")
axes[0][1].set_ylabel("Использование CPU (%)")
axes[0][1].set_title("Зависимость использования CPU от времени")
axes[0][1].grid(True)
axes[0][1].legend()

axes[0][2].plot(numpy_inv_res["timestamp"], numpy_inv_res["memory_percent"], label="Numpy", color="blue")
axes[0][2].plot(scipy_inv_res["timestamp"], scipy_inv_res["memory_percent"], label="Scipy", color="red")
axes[0][2].set_ylabel("Использование RAM (%)")
axes[0][2].set_title("Зависимость использования RAM от времени")
axes[0][2].grid(True)
axes[0][2].legend()

axes[0][3].plot(numpy_inv_res["timestamp"], numpy_inv_res["read_bytes"], label="Чтение (Numpy)", color="blue")
axes[0][3].plot(numpy_inv_res["timestamp"], numpy_inv_res["write_bytes"], label="Запись (Numpy)", color="purple")
axes[0][3].plot(scipy_inv_res["timestamp"], scipy_inv_res["read_bytes"], label="Чтение (Scipy)", color="red")
axes[0][3].plot(scipy_inv_res["timestamp"], scipy_inv_res["write_bytes"], label="Запись (Scipy)", color="orange")
axes[0][3].set_ylabel("Байты")
axes[0][3].set_title("Чтение и запись")
axes[0][3].grid(True)
axes[0][3].legend()

# === График 2: Решение системы линейных уравнений ===
# axes[1].plot(numpy_solve_avg.index, numpy_solve_avg.values, label="NumPy", marker="o", color="b")
# axes[1].plot(scipy_solve_avg.index, scipy_solve_avg.values, label="SciPy", marker="s", color="r")
# axes[1].set_title("System of Linear Equations Solving Time")
# axes[1].set_xlabel("Matrix Size")
# axes[1].set_ylabel("Time (s)")
# axes[1].legend()
# axes[1].grid()

axes[1][0].plot(numpy_solve["matrix_size"], numpy_solve["time"], label="NumPy", marker="o", color="b")
axes[1][0].plot(scipy_solve["matrix_size"], scipy_solve["time"], label="SciPy", marker="o", color="r")
axes[1][0].set_title("Решение системы уравнений")
axes[1][0].set_xlabel("Размер матрицы")
axes[1][0].set_ylabel("Время (секунды)")
axes[1][0].legend()
axes[1][0].grid()

axes[1][1].plot(numpy_solve_res["timestamp"], numpy_solve_res["cpu_percent"], label="Numpy", color="blue")
axes[1][1].plot(scipy_solve_res["timestamp"], scipy_solve_res["cpu_percent"], label="Scipy", color="red")
axes[1][1].set_ylabel("Использование CPU (%)")
axes[1][1].set_title("Зависимость использования CPU от времени")
axes[1][1].grid(True)
axes[1][1].legend()

axes[1][2].plot(numpy_solve_res["timestamp"], numpy_solve_res["memory_percent"], label="Numpy", color="blue")
axes[1][2].plot(scipy_solve_res["timestamp"], scipy_solve_res["memory_percent"], label="Scipy", color="red")
axes[1][2].set_ylabel("Использование RAM (%)")
axes[1][2].set_title("Зависимость использования RAM от времени")
axes[1][2].grid(True)
axes[1][2].legend()

axes[1][3].plot(numpy_solve_res["timestamp"], numpy_solve_res["read_bytes"], label="Чтение (Numpy)", color="blue")
axes[1][3].plot(numpy_solve_res["timestamp"], numpy_solve_res["write_bytes"], label="Запись (Numpy)", color="purple")
axes[1][3].plot(scipy_solve_res["timestamp"], scipy_solve_res["read_bytes"], label="Чтение (Scipy)", color="red")
axes[1][3].plot(scipy_solve_res["timestamp"], scipy_solve_res["write_bytes"], label="Запись (Scipy)", color="orange")
axes[1][3].set_ylabel("Байты")
axes[1][3].set_title("Чтение и запись")
axes[1][3].grid(True)
axes[1][3].legend()

# Добавление общего заголовка
fig.suptitle("Benchmark: NumPy vs SciPy", fontsize=16)

# Настройка внешнего вида и сохранение графика
plt.tight_layout(rect=[0, 0, 1, 0.96])  # Оставляем место для общего заголовка
plt.savefig("./images/benchmark_time_comparison.png")
manager = plt.get_current_fig_manager()
# manager.window.state('zoomed')
plt.show()