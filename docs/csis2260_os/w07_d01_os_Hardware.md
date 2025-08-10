# 📅 Week 7 – CSIS 2260 (Operating Systems) – Survey Week with Practice

## **Day 1 – Hardware & System Overview**

### 🔍 Concepts

- CPU, memory, storage, I/O devices
- Microprocessor architecture: ALU, control unit, registers
- Instruction cycle: fetch → decode → execute → store

### 📖 Theory Notes

- **CPU (Central Processing Unit)**: Brain of the computer; executes instructions.
- **ALU (Arithmetic Logic Unit)**: Performs arithmetic (+, -, \*, /) and logic (AND, OR, NOT) operations.
- **Control Unit (CU)**: Directs data flow between CPU, memory, and peripherals.
- **Registers**: Small, fast storage locations inside the CPU.
- **Instruction Cycle**:
  1. **Fetch** – Retrieve instruction from memory.
  2. **Decode** – Determine the operation and required data.
  3. **Execute** – Perform the operation.
  4. **Store** – Save the result.

---

### ✍️ Pseudocode Test

```
START
  LOAD instruction from memory
  DECODE instruction
  EXECUTE instruction
  STORE result
REPEAT until program ends
END
```

---

### 🧪 Code Simulation (Python Example)

```python
instructions = ["ADD 2 3", "MUL 4 5", "SUB 10 7"]

def execute(instruction):
    parts = instruction.split()
    op, a, b = parts[0], int(parts[1]), int(parts[2])
    if op == "ADD":
        return a + b
    elif op == "SUB":
        return a - b
    elif op == "MUL":
        return a * b

for instr in instructions:
    print(f"FETCH: {instr}")
    print("DECODE")
    result = execute(instr)
    print(f"EXECUTE → result = {result}")
    print("STORE result in register\n")
```

---

### ❓ Quiz

1. Which CPU part performs arithmetic?
2. Which step of the instruction cycle comes after fetch?

---

**✅ Deliverable for Day 1**

- Notes on CPU components & instruction cycle.
- Completed pseudocode test.
- Working code simulation in Python or JS.
- Quiz answers recorded.

