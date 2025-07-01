# 🧠 Instructions & Programs  
_Crash Course Computer Science #8_

This video instructs me that the CPU has limited operation codes, so changeable programs are required.  

---

## 🔁 Programmable Features  

The thing that makes a CPU powerful is the fact that it is **programmable**.  
So, the CPU is a piece of hardware which is controlled by **easy-to-modify software**.  
The power of software is its flexibility.  
Software also allowed us to do something our hardware could not.

---

## 🧩 The Opcode Development  

The instruction table has opcodes like:  
- `LOAD A`  
- `LOAD B`  
- `STORE A`  
- `ADD`  
- `SUB`  
- `JUMP`  
- `JUMP_NEG`  
- `HALT`  

For example:  
- The `JUMP` only happens if a certain condition is met.  
- Similarly, there are `JUMP if equal`, `JUMP if greater`, etc.

Since opcodes have limited bits, modern CPUs solve this in two ways:  
1. **Instruction Length** – Increase the bit width (e.g., 32-bit, 64-bit instructions).  
2. **Variable Length Instruction** – Adjust instruction size depending on the opcode.  

Example:  
- `HALT` instruction doesn’t need extra values.  
- `JUMP` instruction uses the address space before the order.  

---

## 🖥️ CPU Evolution  

- **Intel 4004** (1971): First CPU on a single chip, with 46 instructions.  
- **Modern CPUs** (e.g., Intel Core i7): Thousands of instructions ranging from 1 to 16 bytes long.