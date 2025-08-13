from collections import deque
from dataclasses import dataclass

@dataclass
class Process:
    pid: str
    remaining: int

class SchedulingStrategy:
    def dequeue_next(self, ready: deque[Process]) -> Process:
        raise NotImplementedError

class Fcfs(SchedulingStrategy):
    def dequeue_next(self, ready: deque[Process]) -> Process:
        return ready.popleft()

class Sjf(SchedulingStrategy):
    def dequeue_next(self, ready: deque[Process]) -> Process:
        best = None
        for _ in range(len(ready)):
            p = ready.popleft()
            if best is None or p.remaining < best.remaining:
                if best is not None:
                    # 1. if new min p -> move 'best' back to the queue
                    ready.append(best)
                # 0. initialize
                # 2. best <- p
                best = p
            else:
                # 3. if p is bigger than best -> move back 'p' to the queue
                ready.append(p)
        return best

class Rr(SchedulingStrategy):
    def dequeue_next(self, ready: deque[Process]) -> Process:
        return ready.popleft()

class Scheduler:
    def __init__(self, ready: deque[Process], strategy: SchedulingStrategy, quantum: int):
        assert quantum > 0
        self.ready, self.strategy, self.quantum = ready, strategy, quantum

    def run(self):
        while self.ready:
            p = self.strategy.dequeue_next(self.ready)
            run = min(self.quantum, p.remaining)
            print(f"Running {p.pid} for {run} units")
            p.remaining -= run
            if p.remaining > 0:
                self.ready.append(p)

if __name__ == '__main__':
    base = deque([
        Process("P1", 5),
        Process("P2", 3),
        Process("P3", 8)
    ])
    print("-"*40)
    print("FCFS: ")
    print("-"*40)
    Scheduler(deque(Process(p.pid, p.remaining) for p in base), Fcfs(), 10**9).run()
    print("-"*40)
    print("SJF: ")
    print("-"*40)
    Scheduler(deque(Process(p.pid, p.remaining) for p in base), Sjf(), 10**9).run()
    print("-"*40)
    print("Rr: ")
    print("-"*40)
    Scheduler(deque(Process(p.pid, p.remaining) for p in base), Rr(), 2).run()