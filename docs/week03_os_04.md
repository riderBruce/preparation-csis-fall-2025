# 📘 CSIS 2260 Preview - Day 4: Memory Management

## 🎯 Goal

Understand how memory is organized, allocated, and managed in an operating system, including concepts like paging, segmentation, and virtual memory.

---

## 🧠 Key Concepts

### 1. RAM & Memory Hierarchy

- **Registers** < **Cache** < **Main Memory (RAM)** < **Storage**
- CPU accesses memory in this order for speed.
- RAM is volatile and fast; HDD/SSD is non-volatile but slower.

### 2. Memory Allocation Techniques

- **Contiguous Allocation**: entire memory block is assigned (simple but causes fragmentation)
- **Non-Contiguous Allocation**: memory is split and used more efficiently

---

### 3. Paging

- Memory is divided into fixed-size **pages**.
- Process memory is split into **page frames**.
- No external fragmentation, but internal fragmentation may occur.

> 📌 Example: If page size is 4 KB, a 10 KB process takes 3 pages.

### 4. Segmentation

- Memory is divided based on **logical segments** like code, stack, heap.
- More flexible than paging but vulnerable to external fragmentation.

---

### 5. Virtual Memory

- Uses **disk** space to simulate more RAM.
- Enables **more processes** to run than physical memory allows.
- Implements **paging** with a page table and **swap space**.

---

## 🧪 Practice Activity: Simulate Paging

### Pseudocode (simple memory loading simulation)

```python
page_table = {}
page_size = 4  # KB
process_pages = [6, 3, 4]  # Number of pages needed for 3 processes

for pid, num_pages in enumerate(process_pages, start=1):
    page_table[f"P{pid}"] = [f"Frame{frame}" for frame in range(num_pages)]

for process, frames in page_table.items():
    print(f"{process}: {frames}")
```

### Try adding a small simulation like:

- Allocate processes to frames
- Print out how memory frames are assigned
- Add swap logic if memory is full (optional)

## 📺 Suggested Video

- Memory Management in Operating System (easy explanation with visuals)

## 🗂️ Optional Reading

- CrashCourse OS Ep. 5: Memory & Virtual Memory
- Nand2Tetris Chapter: Memory Segments and RAM Logic

## 📌 Key Terms to Review

- Fragmentation (internal vs external)
- Page Table
- Segment Fault
- Swap Space
- Virtual Address vs Physical Address

## ✍️ Journal Prompt

Explain paging and segmentation in your own words with examples.
What’s the difference between virtual memory and RAM?
