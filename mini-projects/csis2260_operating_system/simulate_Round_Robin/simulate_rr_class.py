class Process:
    def __init__(self, pid, arrival_time, burst_time):
        self.pid = pid
        self.arrival_time = arrival_time
        self.burst_time = burst_time
        self.remaining_time = burst_time
        self.completion_time = 0
        self.turnaround_time = 0
        self.waiting_time = 0


class RoundRobinScheduler:
    def __init__(self, processes, quantum):
        self.processes = processes
        self.quantum = quantum
        self.time = 0
        self.gantt_chart = []

    def is_finished(self):
        return all(p.remaining_time == 0 for p in self.processes)

    def run(self):
        queue = []
        visited = [False] * len(self.processes)

        while not self.is_finished():
            # Enqueue newly arrived processes
            for i, process in enumerate(self.processes):
                if not visited[i] and process.arrival_time <= self.time:
                    queue.append(process)
                    visited[i] = True

            if not queue:
                self.time += 1
                continue

            current = queue.pop(0)

            self.gantt_chart.append((self.time, current.pid))

            if current.remaining_time > self.quantum:
                self.time += self.quantum
                current.remaining_time -= self.quantum
            else:
                self.time += current.remaining_time
                current.remaining_time = 0
                current.completion_time = self.time

            # Re-enqueue new arrivals during execution time
            for i, process in enumerate(self.processes):
                if not visited[i] and process.arrival_time <= self.time:
                    queue.append(process)
                    visited[i] = True

            # Re-enqueue the current process if not finished
            if current.remaining_time > 0:
                queue.append(current)

    def calculate_metrics(self):
        for p in self.processes:
            p.turnaround_time = p.completion_time - p.arrival_time
            p.waiting_time = p.turnaround_time - p.burst_time

    def print_results(self):
        print("Gantt Chart:")
        for t, pid in self.gantt_chart:
            print(f"{t} | {pid}", end=" ")
        print("\n")

        print("Completion Times:")
        for p in self.processes:
            print(f"{p.pid}: {p.completion_time}", end="  ")
        print("\n")

        print("Turnaround Times:")
        total_ta = 0
        for p in self.processes:
            print(f"{p.pid}: {p.turnaround_time}", end="  ")
            total_ta += p.turnaround_time
        print(f"Average: {total_ta / len(self.processes):.2f}")
        print("\n")

        print("Waiting Times:")
        total_wt = 0
        for p in self.processes:
            print(f"{p.pid}: {p.waiting_time}", end="  ")
            total_wt += p.waiting_time
        print(f"Average: {total_wt / len(self.processes):.2f}")
        print()


if __name__ == '__main__':
    processes = [
        Process("P1", 0, 5),
        Process("P2", 1, 3),
        Process("P3", 2, 1),
        Process("P4", 3, 2)
    ]
    rr = RoundRobinScheduler(processes, quantum=2)
    rr.run()
    rr.calculate_metrics()
    rr.print_results()