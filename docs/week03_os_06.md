# ✅ Day 6 Mission: File I/O in Python (OS-flavored)

You’ll practice how files are:
- Opened, read, written
- Simulated like a mini file system (very simplified)
- Interacted with through code like an operating system might



## 📦 Practice 1 – Basic File Read/Write
```python
def write_to_file(filename, data):
    with open(filename, 'w') as f:
        f.write(data)
    print(f"✅ Data written to {filename}")

def read_from_file(filename):
    with open(filename, 'r') as f:
        content = f.read()
    print(f"📄 Content of {filename}:")
    print(content)
    
def main():
    content = "Hello, this is a simulated log entry.\nLet's learn File I/O!"
    write_to_file("log.txt", content)
    read_from_file("log.txt")

if __name__ == '__main__':
    main()
```

## 💡 Practice 2 – Append + Simulate OS log file
```python
def append_to_log(filename, process_id, action):
    with open(filename, 'a') as f:
        f.write(f"P{process_id} | {action}\n")

append_to_log("os_log.txt", 1, "Loaded into memory")
append_to_log("os_log.txt", 2, "Swapped out")
append_to_log("os_log.txt", 3, "Completed execution")
```

## 🧠 Practice 3 – Load process from CSV

Let’s say we have a file like processes.csv:
```python
import csv

def load_processes_from_csv(filename):
    processes = []
    with open(filename, 'r') as f:
        reader = csv.DictReader(f)
        for row in reader:
            pid = int(row['pid'])
            arrival = int(row['arrival'])
            burst = int(row['burst'])
            processes.append((pid, arrival, burst))
    return processes
```

Would you like to practice a mini project using CSV to load processes into a scheduler? Or generate a .txt memory log while allocating frames like in your paging simulation?