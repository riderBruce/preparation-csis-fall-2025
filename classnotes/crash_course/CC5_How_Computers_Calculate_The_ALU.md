# How Computers Calculate: The ALU

Crash Course #5

The **ALU** (Arithmetic Logic Unit) consists of **Arithmetic Units** and **Logic Units**.

## 🧮 Arithmetic Units

- Arithmetic units handle **calculations**.
- It's helpful to memorize the **XOR gate**, which is built using four basic gates:
  - **OR → AND → NOT → AND**
- A **Half Adder** consists of:
  - 1 XOR gate  
  - 1 AND gate  
- A **Full Adder** is made from:
  - 2 Half Adders  
  - 1 OR gate  
- An **8-bit Ripple Carry Adder** is made of:
  - 1 Half Adder  
  - 7 Full Adders  
  → It allows calculation of 8-bit binary numbers — a major advancement.

### ⚠️ Overflow

- Overflow happens when the result **exceeds the bit limit** of the adder.
- To handle bigger numbers, computers use **16-bit, 32-bit, or even wider adders**.

### 🛠️ ALU Operations

Modern ALUs typically support **at least 8 operations**:

- ADD  
- ADD with Carry  
- SUBTRACT  
- SUBTRACT with Borrow  
- NEGATE  
- INCREMENT  
- DECREMENT  
- PASS THROUGH  

Each operation uses its **own logic circuit**.

> Basic ALUs don’t multiply or divide directly.  
> These are done through **repeated additions or subtractions**.  
> Advanced processors include multiplication/division circuits, which require many more logic gates.

---

## 🔘 Logic Units

- ALUs also contain **logic gates** (AND, OR, NOT).
- Used for **simple tests**, such as checking if a value is **zero**.

---

## 🧠 Intel 74181

- A historical 4-bit ALU with **~70 logic gates**.
- It couldn’t multiply or divide.
- Despite limitations, it was a major milestone in **miniaturization** and led to:
  - More capable
  - Less expensive computers

---

## 📐 8-bit ALU Design Diagram (Described)

The typical **8-bit ALU** is presented in a **"V" shape**:

- **Two 8-bit Inputs**
- **4-bit Operation Code**
- **8-bit Output**
- **Flags**:
  - Overflow  
  - Zero  
  - Negative  

---

## ✅ Key Concepts to Remember

| Concept             | Description                               |
|---------------------|-------------------------------------------|
| Half Adder          | XOR + AND                                  |
| Full Adder          | 2 Half Adders + OR                         |
| Ripple Carry Adder  | Chain of adders for multi-bit addition     |
| ALU Tasks           | Arithmetic and Logic Operations            |
| Overflow            | When result exceeds fixed number of bits  |
| Intel 74181         | Early ALU, paved the way for modern CPUs  |

---
