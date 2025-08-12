class Process {
  constructor(pid, time) {
    this.pid = pid;
    this.time = time;
  }
}

class Scheduler {
  constructor(processes, quantum) {
    this.processes = processes;
    this.quantum = quantum;
  }

  run() {
    while (this.processes.length > 0) {
      const process = this.processes.shift();
      const runTime = Math.min(this.quantum, process.time);
      console.log(`Running ${process.pid} for ${runTime} units.`);
      if (process.time > this.quantum) {
        process.time -= this.quantum;
        this.processes.push(process);
      }
    }
  }
}

const processes = [
  new Process("P1", 5),
  new Process("P2", 3),
  new Process("P3", 8),
];

const scheduler = new Scheduler(processes, 2);
scheduler.run();
