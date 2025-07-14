# 📅 Day 2: Processes and Threads (CSIS 2260 Preview)

## 🎯 Goals

- Understand the difference between a **process** and a **program**.
- Learn the various **states** of a process.
- Grasp the basics of **threads**, **multithreading**, and **multiprocessing**.
- Begin exploring real system process monitors (Windows, macOS, Linux).

## 📘 Topics to Cover

### ✅ Process vs Program

- A **program** is a passive set of instructions.
- A **process** is an active instance of a program in execution.

### ✅ States of a Process

- New → Ready → Running → Waiting → Terminated
- May vary slightly by OS, but the concept is universal.

### ✅ Threads

- Lightweight processes that share resources.
- **Multithreading**: Multiple threads within a single process.
- **Multiprocessing**: Running multiple processes on multiple CPUs/cores.

## ▶️ Watch (20–30 min)

- [A PROGRAM is not a PROCESS.](https://www.youtube.com/watch?v=7ge7u5VUSbE)
- [Process State](https://www.youtube.com/watch?v=jZ_6PXoaoxo)
- [Process Vs Threads in Operating System](https://www.youtube.com/watch?v=ogRrL8ZjsVA)
- [Multithreading vs Multiprocessing | System Design](https://www.youtube.com/watch?v=PgDaJEjlBuI)
- [What is Pseudocode Explained](https://www.youtube.com/watch?v=qfckDdsEIq8)

## ✍️ Do

### 🧠 1. Draw or Label the Process Life Cycle

- Diagram the five major states and transitions:

  ```text
  [New] → [Ready] → [Running] → [Waiting] → [Terminated]
  ```

### 💻 2. Explore Running Processes

- **Windows**: Open _Task Manager_ → Go to _Details_ tab → Observe process names and CPU use.
- **macOS**: Open _Activity Monitor_ → Check “Processes” tab.
- **Linux/WSL/macOS terminal**: Use commands like:

  ```plaintext
  ps aux 
    - check processes 
    - STAT (RSDTZ: Run, Sleep, in Disk wait, sTopped, Zombie)
  top - Check the current process and CPU, Memory %
  htop - need to setup, similar with top
  ```

### 🧪 3. Pseudocode Practice

- Write pseudocode to simulate a program going through Ready → Running → Waiting → Terminated.

  Example:

  ```plaintext
  start_program()
  load_to_memory()
  state = "Ready"
  while not finished:
      if CPU_available():
        state = "Running"
        execute_task()
      else:
        state = "Waiting"
  state = "Terminated"
  ```

## ✅ Checkpoint

- I can explain what a process is and how it differs from a program.
- I can list and describe all process states.
- I understand what a thread is and how it differs from a process.
- I observed real processes running on my system.
