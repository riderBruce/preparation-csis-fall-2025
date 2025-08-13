class Process {
  constructor(pid, remaining) {
    this.pid = pid;
    this.remaining = remaining;
  }
}

class FcfsStrategy {
  dequeueNext(q) {
    return q.shift();
  }
}

class SjfStrategy {
  dequeueNext(q) {
    if (q.length === 0) throw new Error("empty");
    let bestIdx = 0;
    for (let i = 1; i < q.length; i++) {
      if (q[i].remaining < q[bestIdx].remaining) bestIdx = i;
    }
    return q.splice(bestIdx, 1)[0];
  }
}

class RrStrategy {
  dequeueNext(q) {
    return q.shift();
  }
}

class Scheduler {
  constructor(ready, strategy, quantum) {
    if (quantum <= 0) throw new Error("quantum must be > 0");
    this.ready = [...ready];
    this.strategy = strategy;
    this.quantum = quantum;
  }
  run() {
    while (this.ready.length > 0) {
      const p = this.strategy.dequeueNext(this.ready);
      const run = Math.min(this.quantum, p.remaining);
      console.log(`Running ${p.pid} for ${run} units`);
      p.remaining -= run;
      if (p.remaining > 0) this.ready.push(p);
    }
  }
}

const base1 = [new Process("P1", 5), new Process("P2", 3), new Process("P3", 8)];
console.log("FCFS: ");
new Scheduler(
  base1,
  new FcfsStrategy(),
  Number.MAX_SAFE_INTEGER
).run();
console.log("-".repeat(40));

const base2 = [new Process("P1", 5), new Process("P2", 3), new Process("P3", 8)];

console.log("SJF: ");
new Scheduler(
  base2.copyWithin(),
  new SjfStrategy(),
  Number.MAX_SAFE_INTEGER
).run();
console.log("-".repeat(40));

const base3 = [new Process("P1", 5), new Process("P2", 3), new Process("P3", 8)];

console.log("RR: ");
new Scheduler(
  base3.copyWithin(),
  new RrStrategy(),
  2
).run();
console.log("-".repeat(40));