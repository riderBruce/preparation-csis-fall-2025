# 📅 Week 7 – CSIS 2260 (Operating Systems) – Survey Week with Practice

**Goal:**\
Touch all major OS topics from the course outline in 7 days, combining:

- Theory
- Pseudocode tests
- Code simulations
- Short quizzes

---

## **Day 1 – Hardware & System Overview**

- 🔍 Concepts:
  - CPU, memory, storage, I/O devices
  - Microprocessor architecture: ALU, control unit, registers
  - Instruction cycle: fetch → decode → execute → store
- ▶️ Watch:
  - CrashCourse Ep. 7 & 8
- ✍️ Pseudocode Test:
  ```
  START
    LOAD instruction from memory
    DECODE instruction
    EXECUTE instruction
    STORE result
  REPEAT until program ends
  END
  ```
- 🧪 Code Simulation:
  - Write a Python or JS script that simulates a simple instruction cycle for 3 sample instructions.
- ❓ Quiz:
  1. Which CPU part performs arithmetic?
  2. Which step of the instruction cycle comes after fetch?

---

## **Day 2 – OS Introduction & Roles**

- 🔍 Concepts:
  - OS as resource manager
  - Types: batch, time-sharing, distributed, real-time
- ✍️ Pseudocode Test:
  ```
  IF resource request
    CHECK availability
    IF available THEN allocate
    ELSE wait
  ENDIF
  ```
- 🧪 Code Simulation:
  - Simulate a resource allocation table for 3 processes using arrays or dictionaries.
- ❓ Quiz:
  1. Name 3 types of operating systems.
  2. Which OS type is best for air-traffic control?

---

## **Day 3 – Processes & Threads**

- 🔍 Concepts:
  - Process states, PCB, multithreading
- ✍️ Pseudocode Test:
  ```
  PROCESS start → NEW
  NEW → READY
  READY → RUNNING
  RUNNING → WAITING or TERMINATED
  ```
- 🧪 Code Simulation:
  - Create a simple state transition simulator that moves a process between states using user input.
- ❓ Quiz:
  1. What’s the difference between a process and a program?
  2. Which state means “waiting for I/O”?

---

## **Day 4 – Processor Management & Scheduling**

- 🔍 Concepts:
  - FCFS, SJF, RR scheduling
- ✍️ Pseudocode Test (Round Robin):
  ```
  WHILE processes remain
    SELECT next process in queue
    EXECUTE for time quantum
    IF process finished THEN remove
    ELSE add to end of queue
  ENDWHILE
  ```
- 🧪 Code Simulation:
  - Write a scheduling simulator for FCFS, SJF, and RR; print Gantt charts.
- ❓ Quiz:
  1. Which algorithm can cause starvation?
  2. In RR, what is the “time quantum”?

---

## **Day 5 – Memory Management**

- 🔍 Concepts:
  - Paging, segmentation, memory hierarchy
- ✍️ Pseudocode Test:
  ```
  logical_address → page_number, offset
  IF page in frame table
    RETURN frame_number + offset
  ELSE
    PAGE FAULT → load page
  ENDIF
  ```
- 🧪 Code Simulation:
  - Simulate paging with a small page table and logical → physical address translation.
- ❓ Quiz:
  1. What is the main difference between paging and segmentation?
  2. Which is faster: cache or RAM?

---

## **Day 6 – File Systems & I/O**

- 🔍 Concepts:
  - Directory trees, file allocation, RAID
- ✍️ Pseudocode Test:
  ```
  CREATE file
  ALLOCATE blocks based on method (contiguous/linked/indexed)
  UPDATE directory entry
  ```
- 🧪 Code Simulation:
  - Simulate RAID 0 vs RAID 1 data distribution with arrays.
- ❓ Quiz:
  1. Which RAID level offers both redundancy and speed?
  2. What does a file allocation table (FAT) store?

---

## **Day 7 – System Commands & Problem Solving**

- 🔍 Concepts:
  - Commands, scripting, troubleshooting
- ✍️ Pseudocode Test:
  ```
  RUN script.sh
  IF error THEN check logs
  IF known issue THEN apply fix
  ELSE escalate
  ```
- 🧪 Code Simulation:
  - Write a shell script to create a directory, create a file, write text, and display its contents.
- ❓ Quiz:
  1. What does `man` do in Linux?
  2. Which command creates an empty file?

---

**✅ End-of-Week Deliverables:**

- All pseudocode exercises completed in a `.txt` or `.md` file.
- All code simulations tested in Python/JS and saved.
- One final quiz review session.

