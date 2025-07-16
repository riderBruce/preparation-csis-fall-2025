# ✅ Base Process class (same for all schedulers)

class Process:
    def __init__(self, pid, arrival_time, burst_time):
        self.pid = pid
        self.arrival_time = arrival_time
        self.burst_time = burst_time
        self.remaining_time = burst_time
        self.is_visited = False
        self.completion_time = 0
        self.turnaround_time = 0
        self.waiting_time = 0

    def reset(self):
        self.remaining_time = self.burst_time
        self.completion_time = 0
        self.turnaround_time = 0
        self.waiting_time = 0
        self.is_visited = False


class BaseScheduler:
    def __init__(self, processes):
        self.processes = processes
        self.time = 0
        self.gantt_chart = []

    def calculate_metrics(self):
        for p in self.processes:
            p.turnaround_time = p.completion_time - p.arrival_time
            p.waiting_time = p.turnaround_time - p.burst_time

    def print_results(self):
        print("Gantt Chart:")
        for t, pid in self.gantt_chart:
            print(f"{t} | {pid}", end="  ")
        print("\n")

        total_ta = total_wt = 0
        print("Turnaround Times:")
        for p in self.processes:
            print(f"{p.pid}: {p.turnaround_time}", end="  ")
            total_ta += p.turnaround_time
        print(f"Average: {total_ta / len(self.processes):.2f}\n")

        print("Waiting Times:")
        for p in self.processes:
            print(f"{p.pid}: {p.waiting_time}", end="  ")
            total_wt += p.waiting_time
        print(f"Average: {total_wt / len(self.processes):.2f}\n")


# ✅ FCFS Scheduler (First-Come, First-Served)

class FCFSScheduler(BaseScheduler):
    def __init__(self, processes):
        super().__init__(sorted(processes, key=lambda p: p.arrival_time))

    def run(self):
        for p in self.processes:
            if self.time < p.arrival_time:
                self.time = p.arrival_time
            self.gantt_chart.append((self.time, p.pid))
            self.time += p.burst_time
            p.completion_time = self.time
        self.gantt_chart.append((self.time, "Finished"))


# ✅ SJF Scheduler (Shortest Job First, non-preemptive)

class SJFScheduler(BaseScheduler):
    def is_ready(self, p):
        return p.arrival_time <= self.time and p.completion_time == 0

    def get_ready_processes(self):
        return [p for p in self.processes if self.is_ready(p)]

    @staticmethod
    def pick_shortest_burst_time(ready):
        return min(ready, key=lambda p: p.burst_time)

    def run(self):
        completed = 0
        n = len(self.processes)

        while completed < n:
            ready = self.get_ready_processes()
            if not ready:
                self.time += 1
                continue
            current = self.pick_shortest_burst_time(ready)
            self.gantt_chart.append((self.time, current.pid))
            self.time += current.burst_time
            current.completion_time = self.time
            completed += 1
        self.gantt_chart.append((self.time, "Finished"))


class RoundRobinScheduler(BaseScheduler):
    def __init__(self, processes, quantum):
        super().__init__(processes)
        self.quantum = quantum
        self.time = 0
        self.queue = []
        self.gantt_chart = []

    def is_finished(self):
        return all(p.remaining_time == 0 for p in self.processes)

    def is_newly_arrived(self, p):
        return not p.is_visited and p.arrival_time <= self.time

    def enqueue_arrived_processes(self):
        for process in self.processes:
            if self.is_newly_arrived(process):
                self.queue.append(process)
                process.is_visited = True

    def run(self) -> None:
        while not self.is_finished():
            # enqueue
            self.enqueue_arrived_processes()
            # wait
            if not self.queue:
                self.time += 1
                continue
            # pop first queue
            current = self.queue.pop(0)
            # CPU running
            self.gantt_chart.append((self.time, current.pid))
            # Update
            if current.remaining_time > self.quantum:
                self.time += self.quantum
                current.remaining_time -= self.quantum
            else:
                self.time += current.remaining_time
                current.remaining_time = 0
                current.completion_time = self.time
            # Refresh : enqueue current process after new arrival
            self.enqueue_arrived_processes()
            if current.remaining_time > 0:
                self.queue.append(current)
        # wrap up
        self.gantt_chart.append((self.time, "Finished"))


def main():
    original = [
        Process("P1", 0, 5),
        Process("P2", 1, 3),
        Process("P3", 2, 1),
        Process("P4", 3, 2),
    ]

    # FCFS
    print("=== FCFS ===")
    fcfs_processes = [Process(p.pid, p.arrival_time, p.burst_time) for p in original]
    fcfs = FCFSScheduler(fcfs_processes)
    fcfs.run()
    fcfs.calculate_metrics()
    fcfs.print_results()

    # SJF
    print("=== SJF (non-preemptive) ===")
    sjf_processes = [Process(p.pid, p.arrival_time, p.burst_time) for p in original]
    sjf = SJFScheduler(sjf_processes)
    sjf.run()
    sjf.calculate_metrics()
    sjf.print_results()

    # Round Robin
    print("=== Round Robin ===")
    rr_processes = [Process(p.pid, p.arrival_time, p.burst_time) for p in original]
    rr = RoundRobinScheduler(rr_processes, quantum=2)
    rr.run()
    rr.calculate_metrics()
    rr.print_results()


if __name__ == '__main__':
    main()
