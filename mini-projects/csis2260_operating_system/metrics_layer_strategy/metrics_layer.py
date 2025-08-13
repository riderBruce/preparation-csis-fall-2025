from collections import deque
from dataclasses import dataclass
from typing import Deque, Protocol, Dict

@dataclass
class Process:
    pid: str
    remaining: int
    priority: int = 0

class SchedulingStrategy(Protocol):
    def dequeue_next(self, ready: Deque[Process]) -> Process: ...

class Fcfs:
    def dequeue_next(self, ready: Deque[Process]) -> Process:
        return ready.popleft()
    
class Sjf:
    def dequeue_next(self, ready: Deque[Process]) -> Process:
        best = None
        for _ in range(len(ready)):
            p = ready.popleft()
            if best is None or p.remaining < best.remaining:
                if best is not None:
                    ready.append(best)
                best = p
            else:
                ready.append(p)
        return best

class PrioritySched:
    def dequeue_next(self, ready: Deque[Process]) -> Process:
        # lower priority value first
        best = None
        for _ in range(len(ready)):
            p = ready.popleft()
            if best is None or p.priority < best.priority:
                if best is not None:
                    ready.append(best)
                best = p
            else:
                ready.append(p)
        return best
    
class Metrics:
    def __init__(self):
        self.context_switches = 0
        self.first_response: Dict[str, int] = {}
        self.finish_time: Dict[str, int] = {}
        self.burst_seen: Dict[str, bool] = {}
        self.now = 0

    def on_dispatch(self, p: Process):
        self.context_switches += 1
        if p.pid not in self.burst_seen:
            self.first_response[p.pid] = self.now
            self.burst_seen[p.pid] = True

    def on_execute(self, run: int):
        self.now += run
    
    def on_complete(self, p: Process):
        self.finish_time[p.pid] = self.now

    def summary(self, original_bursts: Dict[str, int]):
        res = {}
        for pid, total in original_bursts.items():
            ft = self.finish_time[pid]
            rt = self.first_response.get(pid, 0)
            tat = ft # arrival=0
            wt = tat - total
            res[pid] = {"response": rt, "turnaround": tat, "waiting": wt}
        return {
            "per_process": res,
            "context_switches": self.context_switches,
            "makespan": self.now,
        }
    
class Scheduler:
    def __init__(self, ready: Deque[Process], strategy: SchedulingStrategy, quantum: int):
        assert quantum > 0
        self.ready = ready
        self.strategy = strategy
        self.quantum = quantum
        self.metrics = Metrics()
        self.original = {p.pid: p.remaining for p in list(ready)}

    def run(self):
        while self.ready:
            p = self.strategy.dequeue_next(self.ready)
            self.metrics.on_dispatch(p)
            run = min(self.quantum, p.remaining)
            p.remaining -= run
            self.metrics.on_execute(run)
            if p.remaining > 0:
                self.ready.append(p)
            else:
                self.metrics.on_complete(p)
        return self.metrics.summary(self.original)


if __name__ == "__main__":
    base = deque([
        Process("P1", 5, priority=2),
        Process("P2", 3, priority=1),
        Process("P3", 8, priority=3),
    ])
    print("FCFS:", Scheduler(deque(base), Fcfs(), 10**9).run())
    print("SJF:", Scheduler(deque(base), Sjf(), 10**9).run())
    print("PRIO:", Scheduler(deque(base), PrioritySched(), 10**9).run())
    print("RR q=2:", Scheduler(deque(base), Fcfs(), 2).run())