# 🧾 CSIS 2260 Preview – Day 4 Journal

## 🧠 Memory and Storage Timeline (CC19 Review)

### 🔁 Volatile vs Non-Volatile Memory

- **Volatile Memory**: loses data when power is off (e.g., RAM)
- **Non-Volatile Memory**: retains data even when power is off (e.g., HDD, SSD)

### 🕰️ Historical Devices

- **Punch Card / Tape (1940s)**

  - Write-once medium. Editing was difficult.
  - SAGE program used 62,500 punch cards (~5MB)

- **Delay Line Memory (EDVAC)**

  - Stored bits as waves in liquid.
  - Used in early **stored-program computers**

- **Magnetic Core Memory (1950s–1970s)**
  - First RAM. Expensive, but durable and widely used.
  - Adopted in MIT's _Whirlwind I_ in 1953.

### 💽 Evolving Storage

- **Magnetic Tape (Univac)**

  - Still used for backups and archives today.

- **Magnetic Drum Memory → Hard Disk Drive (HDD)**

  - Faster than tape, became disk-based storage.
  - IBM RAMAC 305 was first with disk drive.

- **Floppy Disk**

  - Portable and rewritable. Similar tech to HDD, but lower capacity.

- **Optical Disk**
  - Used light instead of magnetism (e.g., Laser Disk, CD, DVD)

### ⚡ Solid State Revolution

- **SSD (Solid State Drives)**
  - Much faster than HDD (short seek time)
  - Now replacing HDD in most systems
  - Still part of the **Memory Hierarchy**

## 🏗️ Concept: Memory Hierarchy

- **Why?** CPU is fast, storage is slow
- **Solution:** Use layers of memory to balance cost and performance
  - **Register** → **Cache** → **RAM** → **SSD/HDD** → **Archive (Tape)**
