# 🧠 Advanced CPU Designs
– Crash Course #9

In the early days of electronic computing, processors were typically made faster by improving the switching time of the transistors inside the chip. But just making transistors faster and more efficient only went so far, so processor designers have developed various techniques.

Not only have computer processors gotten a lot faster over the years, but also a lot more sophisticated, employing all sorts of clever tricks to squeeze out more and more computation per clock cycle.

---

## 🧩 Key Enhancements

### 🔧 Special Circuits
- For graphics operations (e.g., **MMX**, **3DNow**, **SSE**)

### 🧠 Thousands of Instruction Sets
- **Backwards Compatibility**: CPUs must support old opcodes along with new ones.

---

## 🧮 Cache
- **CPU Bottleneck**: RAM is much slower than the CPU.
- **Bus**: Data wires transmitting to and from RAM.
- **Latency**: RAM takes time to locate, retrieve, and send data.
- **Solution**: A small piece of RAM (cache) on the CPU itself.
- **Cache Hit**: Data is already in cache → fast access.
- **Cache Miss**: Must fetch from RAM → slower.
- **Scratch Space**: Cache can be used for temporary calculation storage.
- **Dirty Bit**: Flags that a block of memory in the cache has been changed and needs syncing with RAM.

---

## 🧱 Instruction Pipelining
- **Parallel Operations**: Multiple stages of instruction processed at once.
- **Dependency Handling**:
  - CPUs check for **data dependencies** and **stall pipelines** when necessary.
- **Out-of-Order Execution**: Reorders instructions to avoid stalling.
- **Speculative Execution**:
  - CPUs **guess** the result of conditional jumps.
  - **Pipeline Flush**: If the guess is wrong, discard wrong instructions.
  - **Branch Prediction**: Modern CPUs achieve over **90% accuracy**.

---

## 🚀 Superscalar Architecture
- Executes **more than one instruction per clock cycle**.

---

## 🧩 Multi-Core Processors
- Multiple processing units on a single CPU chip.

---

## 💻 Supercomputers
- **Sunway TaihuLight (China)**:
  - 40,960 CPUs
  - Each CPU has **256 cores**
  - Over **10 million cores total**
  - **1.45GHz** clock speed
  - Achieves **93 quadrillion FLOPS** (Floating Point Operations Per Second)

---