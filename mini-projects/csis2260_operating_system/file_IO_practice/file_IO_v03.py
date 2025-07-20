import csv


def load_processes_from_csv(filename):
    processes = []
    with open(filename, 'r') as f:
        content = csv.DictReader(f)
        for row in content:
            pid = int(row["pid"])
            arrival = int(row["arrival"])
            burst = int(row["burst"])
            processes.append((pid, arrival, burst))
    return processes

