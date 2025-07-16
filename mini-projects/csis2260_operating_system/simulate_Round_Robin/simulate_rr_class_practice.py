class Process:
    def __init__(self, pid, arrival_time, burst):
        self.pid = pid
        self.arrival_time = arrival_time
        self.burst = burst
        self.remaining_time = burst
        self.is_visited = False
        self.completion_time = 0
        self.turnaround_time = 0
        self.waiting_time = 0


class RoundRobinScheduler:
    def __init__(self, processes, quantum):
        self.processes = processes
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

    def calculate_metrics(self) -> None:
        for p in self.processes:
            p.turnaround_time = p.completion_time - p.arrival_time
            p.waiting_time = p.turnaround_time - p.burst

    def print_results(self) -> None:
        print("Gantt Chart: ")
        for t, pid in self.gantt_chart:
            print(f"{t} | {pid}", end="  ")
        print("\n")

        print("Completion Times: ")
        for p in self.processes:
            print(f"{p.pid}: {p.completion_time}", end="  ")
        print("\n")

        print("Turnaround Times: ")
        total_ta = 0
        for p in self.processes:
            print(f"{p.pid}: {p.turnaround_time}", end="  ")
            total_ta += p.turnaround_time
        print(f"Average: {total_ta / len(self.processes):.2f}")
        print("\n")

        print("Waiting Times: ")
        total_wt = 0
        for p in self.processes:
            print(f"{p.pid}: {p.waiting_time}", end="  ")
            total_wt += p.waiting_time
        print(f"Average: {total_wt / len(self.processes):.2f}")
        print()

    def reset(self):
        self.time = 0
        self.queue = []
        self.gantt_chart = []
        for p in self.processes:
            p.is_visited = False
            p.remaining_time = p.burst
            p.completion_time = 0
            p.turnaround_time = 0
            p.waiting_time = 0


if __name__ == '__main__':
    processes = [
        Process("P1", 0, 5),
        Process("P2", 1, 3),
        Process("P3", 2, 1),
        Process("P4", 3, 2),
    ]

    rr = RoundRobinScheduler(processes, quantum=2)
    rr.run()
    rr.calculate_metrics()
    rr.print_results()
    rr.reset()

