class Process {
  constructor(pid, remaining, priority = 0) {
    this.pid = pid;
    this.remaining = remaining;
    this.priority = priority;
  }
}

class Metrics {
  constructor() {
    this.contextSwitches = 0;
    this.firstResponse = {};
    this.finishTime = {};
    this.burstSeen = {};
    this.now = 0;
  }

  OnDispatch(p) {
    this.contextSwitches++;
    if (!(p.pid in this.burstSeen)) {
      this.firstResponse[p.pid] = this.now;
      this.burstSeen[p.pid] = true;
    }
  }

  onExecute(run) {
    this.now += run;
  }

  onComplete(p) {
    this.finishTime[p.pid] = this.now;
  }

  Summary(original) {
    const per = {};
    for (const [pid, total] of Object.entries(original)) {
      const ft = this.finishTime[pid];
      const rt = this.firstResponse[pid];
      const tat = ft;
      const wt = tat - total;
      per[pid] = { response: rt, turnaround: tat, waiting: wt };
    }
    return {
      per_process: per,
      context_switches: this.contextSwitches,
      makespan: this.now,
    };
  }
}

class FcfsStrategy {
  dequeueNext(q) {
    return q.shift();
  }
}

class SjfStrategy {
  dequeueNext(q) {
    let best = 0;
    for (let i = 1; i < q.length; i++) {
      if (q[i].remaining < q[best].remaining) best = i;
    }
    return q.splice(best, 1)[0];
  }
}

class PriorityStrategy {
  dequeueNext(q) {
    let best = 0;
    for (let i = 1; i < q.length; i++) {
      if (q[i].priority < q[best].priority) best = i;
    }
    return q.splice(best, 1)[0];
  }
}

class Scheduler {
  constructor(ready, strategy, quantum) {
    this.ready = [...ready];
    this.strategy = strategy;
    this.quantum = quantum;
    this.metrics = new Metrics();
    this.original = Object.fromEntries(
      this.ready.map((p) => [p.pid, p.remaining])
    );
  }
  run() {
    while (this.ready.length > 0) {
      const p = this.strategy.dequeueNext(this.ready);
      this.metrics.OnDispatch(p);
      const run = Math.min(this.quantum, p.remaining);
      p.remaining -= run;
      this.metrics.onExecute(run);
      if (p.remaining > 0) {
        this.ready.push(p);
      } else {
        this.metrics.onComplete(p);
      }
    }
    return this.metrics.Summary(this.original);
  }
}

const base1 = [
  new Process("P1", 5, 2),
  new Process("P2", 3, 1),
  new Process("P3", 8, 3),
];
console.log(
  "FCFS:",
  new Scheduler(base1, new FcfsStrategy(), Number.MAX_SAFE_INTEGER).run()
);

const base2 = [
  new Process("P1", 5, 2),
  new Process("P2", 3, 1),
  new Process("P3", 8, 3),
];
console.log(
  "SJF:",
  new Scheduler(base2, new SjfStrategy(), Number.MAX_SAFE_INTEGER).run()
);

const base3 = [
  new Process("P1", 5, 2),
  new Process("P2", 3, 1),
  new Process("P3", 8, 3),
];
console.log(
  "PRIO:",
  new Scheduler(base3, new PriorityStrategy(), Number.MAX_SAFE_INTEGER).run()
);
const base4 = [
  new Process("P1", 5, 2),
  new Process("P2", 3, 1),
  new Process("P3", 8, 3),
];
console.log("RR q=2:", new Scheduler(base4, new FcfsStrategy(), 2).run());
