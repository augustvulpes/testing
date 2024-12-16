import pandas as pd
import numpy as np
import json

def generate_resource_summary(input_csv_files, output_json):
    results = {}

    for file_path in input_csv_files:
        operation_name = file_path.split("/")[1]

        data = pd.read_csv(file_path)

        results[operation_name] = {
            "CPU": {
                "min": data["cpu_percent"].min(),
                "max": data["cpu_percent"].max(),
                "median": np.median(data["cpu_percent"])
            },
            "RAM": {
                "min": data["memory_percent"].min(),
                "max": data["memory_percent"].max(),
                "median": np.median(data["memory_percent"])
            },
            "Read Bytes": {
                "min": data["read_bytes"].min(),
                "max": data["read_bytes"].max(),
                "median": np.median(data["read_bytes"])
            },
            "Write Bytes": {
                "min": data["write_bytes"].min(),
                "max": data["write_bytes"].max(),
                "median": np.median(data["write_bytes"])
            }
        }

    with open(output_json, "w") as json_file:
        json.dump(results, json_file, indent=4)

# Пример использования
if __name__ == "__main__":
    csv_files = ['./numpyInv/res_average.csv', './scipyInv/res_average.csv', './numpySolve/res_average.csv', './scipySolve/res_average.csv']
    output_json_path = "resource_usage_summary.json"

    generate_resource_summary(csv_files, output_json_path)
