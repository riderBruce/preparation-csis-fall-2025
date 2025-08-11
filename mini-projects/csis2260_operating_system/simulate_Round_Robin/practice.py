from collections import deque

class Process:
    def __init__(self, pid, time):
        self.pid = pid
        self.time = time

class Scheduler:
    def __init__(self, processes, quantum):
        self.processes = processes
        self.quantum = quantum
        self.queue = deque()
        
    def run(self):
        for p in self.processes:
            self.queue.append(p)
        while self.queue:
            process = self.queue.popleft()
            print(f"Running {process.pid} for {min(self.quantum, process.time)} units.")
            if process.time <= self.quantum:
                self.time = 0
                continue    
            process.time -= self.quantum
            self.processes.append(process)

def main():
    processes = [
        Process("P1", 5),
        Process("P2", 3),
        Process("P3", 8),
    ]
    sch = Scheduler(processes, quantum=2)
    sch.run()

if __name__ == "__main__":
    main()