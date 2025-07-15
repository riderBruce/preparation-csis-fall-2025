# 📅 Day 3: Scheduling Algorithms (CSIS 2260 Preview)

## 🎯 Goals

- Understand the purpose of CPU scheduling in multitasking environments.
- Learn three major scheduling algorithms: FCFS, SJF, and Round Robin.
- Visualize how scheduling affects CPU efficiency and process wait times.
- Practice building Gantt charts and simulations.

## 📘 Topics to Cover

### ✅ Why Scheduling Matters

- The OS decides **which process gets CPU time** and **when**.
- A good scheduler:
  - Maximizes CPU utilization.
  - Minimizes waiting and turnaround time.
  - Ensures fairness among processes.

### ✅ Key Scheduling Algorithms

1. **First-Come, First-Served (FCFS)**

   - Processes are handled in the order they arrive.
   - Simple, but can cause **convoy effect** (long waits behind big jobs).

2. **Shortest Job First (SJF)**

   - Executes the process with the shortest burst time first.
   - Optimal in terms of average waiting time, but hard to predict burst time.

3. **Round Robin (RR)**
   - Each process gets a fixed time slice (quantum).
   - Preemptive scheduling—great for time-sharing systems.

## ▶️ Watch (Optional, 15–20 min)

- [OS Scheduling Algorithms – Animated Tutorial](https://www.youtube.com/watch?v=kjKRrYhvgF4)
- [GATE Smashers – CPU Scheduling with Gantt Charts](https://www.youtube.com/watch?v=yoDI_oABj1s)

## ✍️ Do

### 📊 1. Gantt Chart Practice

- Draw a Gantt chart for each algorithm using the following sample:

```text
Process | Arrival Time | Burst Time
--------|--------------|---------
   P1   |      0       |     5
   P2   |      1       |     3
   P3   |      2       |     1
   P4   |      3       |     2
```

- Try FCFS, SJF (non-preemptive), and Round Robin (quantum = 2).
- Calculate:
- Turnaround Time = Completion Time – Arrival Time
- Waiting Time = Turnaround Time – Burst Time

### 🔧 2. Spreadsheet or Code Simulation (Optional)

- Use Excel, Google Sheets, or a Python/JavaScript snippet to simulate Round Robin logic.

## ✅ Checkpoint

- I can describe how each scheduling algorithm works.
- I can draw a correct Gantt chart for FCFS, SJF, and RR.
- I calculated waiting and turnaround time for a process.
- I understand how different algorithms affect performance.
