# Day 4.1 – Advanced OOP Scheduling (Strategies + Metrics)

This extends the Strategy-based Scheduler with **Priority Scheduling** and a **Metrics** layer that tracks:

- Context switches
- First response time per process
- Completion time / Turnaround time
- Waiting time (derived)

Assumptions for simplicity:

- All processes arrive at time **0** (no arrivals mid-run).
- Each dispatch runs for `min(quantum, remaining)` time units.
- FCFS/SJF/Priority are modeled as **non-preemptive** by setting a very large quantum; RR is **preemptive** with finite quantum.

---

## Python

```python
from collections import deque
from dataclasses import dataclass
from typing import Deque, Protocol, Dict

@dataclass
class Process:
    pid: str
    remaining: int
    priority: int = 0  # lower = higher priority

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
            tat = ft  # arrival=0
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
    print("RR q=2:", Scheduler(deque(base), Fcfs(), 2).run())  # RR by quantum
```

---

## JavaScript (TypeScript-friendly shape)

```js
class Process {
  constructor(pid, remaining, priority = 0) {
    this.pid = pid; this.remaining = remaining; this.priority = priority;
  }
}
class Metrics {
  constructor(){ this.contextSwitches=0; this.firstResponse={}; this.finishTime={}; this.burstSeen={}; this.now=0; }
  onDispatch(p){ this.contextSwitches++; if(!(p.pid in this.burstSeen)){ this.firstResponse[p.pid]=this.now; this.burstSeen[p.pid]=true; } }
  onExecute(run){ this.now += run; }
  onComplete(p){ this.finishTime[p.pid]=this.now; }
  summary(original){
    const per={};
    for(const [pid,total] of Object.entries(original)){
      const ft=this.finishTime[pid]; const rt=this.firstResponse[pid]||0; const tat=ft; const wt=tat-total;
      per[pid]={response:rt, turnaround:tat, waiting:wt};
    }
    return { per_process: per, context_switches: this.contextSwitches, makespan: this.now };
  }
}
class FcfsStrategy { dequeueNext(q){ return q.shift(); } }
class SjfStrategy { dequeueNext(q){ let best=0; for(let i=1;i<q.length;i++){ if(q[i].remaining<q[best].remaining) best=i; } return q.splice(best,1)[0]; } }
class PriorityStrategy { dequeueNext(q){ let best=0; for(let i=1;i<q.length;i++){ if(q[i].priority<q[best].priority) best=i; } return q.splice(best,1)[0]; } }
class Scheduler {
  constructor(ready, strategy, quantum){ if(quantum<=0) throw new Error('quantum>0'); this.ready=[...ready]; this.strategy=strategy; this.quantum=quantum; this.metrics=new Metrics(); this.original=Object.fromEntries(this.ready.map(p=>[p.pid,p.remaining])); }
  run(){
    while(this.ready.length>0){
      const p=this.strategy.dequeueNext(this.ready);
      this.metrics.onDispatch(p);
      const run=Math.min(this.quantum, p.remaining);
      p.remaining-=run; this.metrics.onExecute(run);
      if(p.remaining>0) this.ready.push(p); else this.metrics.onComplete(p);
    }
    return this.metrics.summary(this.original);
  }
}
// demo
const base=[ new Process('P1',5,2), new Process('P2',3,1), new Process('P3',8,3) ];
console.log('FCFS:', new Scheduler(base, new FcfsStrategy(), Number.MAX_SAFE_INTEGER).run());
console.log('SJF :', new Scheduler(base, new SjfStrategy(), Number.MAX_SAFE_INTEGER).run());
console.log('PRIO:', new Scheduler(base, new PriorityStrategy(), Number.MAX_SAFE_INTEGER).run());
console.log('RR q=2:', new Scheduler(base, new FcfsStrategy(), 2).run()); // RR via quantum
```

---

## C\#

```csharp
using System; using System.Collections.Generic;
public sealed class Process { public string Pid {get;} public int Remaining {get; set;} public int Priority {get;}
  public Process(string pid,int remaining,int priority=0){ Pid=pid; Remaining=remaining; Priority=priority; } }

public interface ISchedulingStrategy { Process DequeueNext(Queue<Process> ready); }
public sealed class FcfsStrategy : ISchedulingStrategy { public Process DequeueNext(Queue<Process> ready)=> ready.Dequeue(); }
public sealed class SjfStrategy  : ISchedulingStrategy {
  public Process DequeueNext(Queue<Process> ready){ if(ready.Count==0) throw new InvalidOperationException();
    Process best=null; int n=ready.Count; for(int i=0;i<n;i++){ var p=ready.Dequeue(); if(best==null||p.Remaining<best.Remaining){ if(best!=null) ready.Enqueue(best); best=p; } else ready.Enqueue(p);} return best; }
}
public sealed class PriorityStrategy : ISchedulingStrategy {
  public Process DequeueNext(Queue<Process> ready){ if(ready.Count==0) throw new InvalidOperationException();
    Process best=null; int n=ready.Count; for(int i=0;i<n;i++){ var p=ready.Dequeue(); if(best==null||p.Priority<best.Priority){ if(best!=null) ready.Enqueue(best); best=p; } else ready.Enqueue(p);} return best; }
}

public sealed class Metrics {
  public int ContextSwitches {get; private set;} = 0; public int Now {get; private set;} = 0;
  private readonly Dictionary<string,int> _firstResponse = new();
  private readonly HashSet<string> _seen = new();
  private readonly Dictionary<string,int> _finish = new();
  public void OnDispatch(Process p){ ContextSwitches++; if(!_seen.Contains(p.Pid)){ _firstResponse[p.Pid]=Now; _seen.Add(p.Pid);} }
  public void OnExecute(int run){ Now+=run; }
  public void OnComplete(Process p){ _finish[p.Pid]=Now; }
  public (Dictionary<string,(int response,int turnaround,int waiting)> per,int context,int makespan) Summary(Dictionary<string,int> original){
    var per = new Dictionary<string,(int,int,int)>();
    foreach(var kv in original){ var pid=kv.Key; var total=kv.Value; int ft=_finish[pid]; int rt=_firstResponse.ContainsKey(pid)?_firstResponse[pid]:0; int tat=ft; int wt=tat-total; per[pid]=(rt,tat,wt);}
    return (per, ContextSwitches, Now);
  }
}

public sealed class Scheduler {
  private readonly Queue<Process> _ready; private readonly ISchedulingStrategy _strategy; private readonly int _quantum; private readonly Metrics _metrics = new(); private readonly Dictionary<string,int> _original;
  public Scheduler(Queue<Process> ready, ISchedulingStrategy strategy, int quantum){ if(quantum<=0) throw new ArgumentException("quantum>0"); _ready=ready; _strategy=strategy; _quantum=quantum; _original=new(); foreach(var p in ready) _original[p.Pid]=p.Remaining; }
  public (Dictionary<string,(int response,int turnaround,int waiting)> per,int context,int makespan) Run(){
    while(_ready.Count>0){ var p=_strategy.DequeueNext(_ready); _metrics.OnDispatch(p); int run=Math.Min(_quantum, p.Remaining); p.Remaining-=run; _metrics.OnExecute(run); if(p.Remaining>0) _ready.Enqueue(p); else _metrics.OnComplete(p);}
    return _metrics.Summary(_original);
  }
}

public static class Demo {
  public static void Main(){
    var baseQ = new Queue<Process>(new[]{ new Process("P1",5,2), new Process("P2",3,1), new Process("P3",8,3)});
    Console.WriteLine("FCFS:"); var s1=new Scheduler(new Queue<Process>(baseQ), new FcfsStrategy(), int.MaxValue); var r1=s1.Run();
    Console.WriteLine($"context={r1.context}, makespan={r1.makespan}");
    Console.WriteLine("SJF:"); var s2=new Scheduler(new Queue<Process>(baseQ), new SjfStrategy(), int.MaxValue); var r2=s2.Run();
    Console.WriteLine($"context={r2.context}, makespan={r2.makespan}");
    Console.WriteLine("PRIO:"); var s3=new Scheduler(new Queue<Process>(baseQ), new PriorityStrategy(), int.MaxValue); var r3=s3.Run();
    Console.WriteLine($"context={r3.context}, makespan={r3.makespan}");
    Console.WriteLine("RR q=2:"); var s4=new Scheduler(new Queue<Process>(baseQ), new FcfsStrategy(), 2); var r4=s4.Run();
    Console.WriteLine($"context={r4.context}, makespan={r4.makespan}");
  }
}
```

### Reflections

- I think Scheduler deals what to do - main logic, and Stratagy takes how to do - sub logic, and Metrics cares about the figure data - results.
- Stratagy classes are injected as a parameter, so when Scheduler is called, it's choosable.
- Metrics class is injected as a property, so Metrics's property and method can be easily accessable.
- Metrics class is just collection of datas that storable and how to store. I think Metrics data and method could be inside of Scheduler class, but just extracted to anothor class. Eventually the figure data will be got together inside of Metrics class, and make a summary for that.
- I wonder if metrics's data is not complicated, it can be just with a object like just Dict. Also, extracting Segments to another class could be a good choice for scalablity.
- As a result, I can easily access the final data with Metrics, and switch methods with same type of Strategy. It's easy with @dataclass inputting and carring data.  
- Every object can be built with Dictionary, it could be built with a class.