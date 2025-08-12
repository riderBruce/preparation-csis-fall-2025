# 🕵️ Code Detective Pattern Book – Week 7 Start

A living cheat sheet of common-enough patterns and idioms we’ll keep adding to. Copy, download, and bring to class.

---

## 1) Initialize-once, then compare (Min/Max scan)

**Why:** Scan a collection once to pick best item without tricky first-iteration code.

**Python**

```python
best = None
for x in items:
    if best is None or score(x) < score(best):
        best = x
```

**C#**

```csharp
T best = default;
bool has = false;
foreach (var x in items) {
    if (!has || Score(x) < Score(best)) { best = x; has = true; }
}
```

**JavaScript**

```js
let best = null;
for (const x of items) {
  if (best === null || score(x) < score(best)) best = x;
}
```

---

## 2) “Pick-and-put-back” queue selection (SJF from a FIFO queue)

**Why:** Choose the best element while preserving queue order for the rest.

**Python (deque)**

```python
best = None
for _ in range(len(q)):
    p = q.popleft()
    if best is None or p.remaining < best.remaining:
        if best is not None: q.append(best)
        best = p
    else:
        q.append(p)
return best  # NOT re-appended
```

**Common pitfall:** Don’t append the new best; append the loser.

---

## 3) Copying vs cloning queues (fair comparisons)

**Why:** Reuse the same starting workload across multiple runs.

**Python**

```python
from collections import deque
base = deque([...])          # original
run1 = deque(base)           # shallow copy of container
# deep clone elements if needed
run2 = deque(Process(p.pid, p.remaining) for p in base)
```

**Note:** `deque(base)` is a *shallow* copy; elements are shared.

---

## 4) JS object access: dot vs bracket

**Why:** Readability & valid identifiers.

```js
obj.key        // dot: only valid identifiers
obj["key"]     // bracket: dynamic or special chars
```

**Python dicts:** always bracket: `d["key"]`. **Pandas perk:** `df.col` works sometimes, but `df["col"]` is safest.

---

## 5) `const` vs `let` (JS)

**Rule of thumb:** Use `const` by default; switch to `let` only if you reassign.

```js
const available = resources[req] ?? 0; // not reassigned
let total = 0; total += price;         // reassigned
```

**Objects/arrays:** `const` locks the *binding*, not the contents.

---

## 6) C# naming & field style

**Conventions:**

- Private fields: `_camelCase` → `_processes`, `_quantum`
- Properties/Methods/Classes: `PascalCase`
- Parameters/locals: `camelCase`

```csharp
private Queue<Process> _processes;
public int Quantum { get; }
```

---

## 7) Strategy Pattern (swap behavior without changing the host)

**Why:** Plug in different algorithms (FCFS/SJF/RR) without editing `Scheduler`.

**C# sketch**

```csharp
public interface ISchedulingStrategy { Process DequeueNext(Queue<Process> q); }
public sealed class Fcfs : ISchedulingStrategy { public Process DequeueNext(Queue<Process> q)=>q.Dequeue(); }
public sealed class Sjf  : ISchedulingStrategy { /* pick shortest */ }
public sealed class Rr   : ISchedulingStrategy { /* dequeue; requeue after quantum */ }

public sealed class Scheduler {
  private readonly ISchedulingStrategy _s;
  public void Run(){ /* ask _s for next; run; requeue if needed */ }
}
```

**Mental hook:** “Swap the *how*, keep the *what*.”

---

## 8) OOP + FP harmony

**Guideline:** Model nouns with classes (Process, Scheduler). Inside methods, keep data steps pure and small (map/filter/reduce, LINQ).

- OOP → structure & evolution
- FP  → crisp transformations

---

## 9) Context switching (concept cue)

**Save** registers/PC/stack → **load** next process → run for quantum → repeat.

**Toy trace**

```
A run, save A → B run, save B → C run, save C → A run ...
```

**Tip:** Smaller quantum ⇒ more overhead; larger ⇒ closer to FCFS.

---

## 10) Detective flags (when to memorize)

- Shows up across languages
- Eliminates special-case branching
- Encapsulates a repeatable idea (min-scan, pick‑and‑put‑back, strategy swap)

> We’ll keep adding to this as we learn new patterns. Ping me whenever something feels like a “riddle.”

