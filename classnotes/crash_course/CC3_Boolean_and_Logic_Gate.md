# 👍Boolean & Logic Gate

Crash Course Computer Science #3

## 🖥️ Video Review

Fortunately, even with just two states of electricity, we can represent all kinds of information. This is called binary, meaning "two states."

It comes from Boolean algebra, developed in the 1800s by George Boole, which itself was inspired by Aristotle’s logic system (under, over, beyond).

In computers:

- An “on” state (electricity is flowing) represents **true**.
- An “off” state (no electricity) represents **false**.
These are also expressed as **1** (true) and **0** (false).

The video introduces four main types of logic gates built using transistors:

- **NOT Gate** – inverts the input. Electricity flows only when the input is off.
- **AND Gate** – uses two transistors in series. Both must be on for electricity to pass.
- **OR Gate** – uses parallel transistors. If either is on, electricity flows.
- **XOR Gate** (exclusive OR) – a bit trickier. It combines OR and AND + NOT gates so that the result is true only when inputs are different.

While programmers don’t usually think about these gates directly, understanding how they work helps explain how computers perform calculations at the hardware level.

## 🚀 Shown it with Python

```python
def not_gate(a: bool) -> bool: 
    return not a
def and_gate(a: bool, b: bool) -> bool: 
    return a and b
def or_gate(a: bool, b: bool) -> bool: 
    return a or b
def xor_gate(a: bool, b: bool) -> bool:
    return (a or b) and not (a and b)
```

### 🧠 Logic Gate Truth Table

| A     | B     | NOT A | A AND B | A OR B | A XOR B |
|-------|-------|--------|----------|--------|----------|
| False | False | True   | False    | False  | False    |
| False | True  | True   | False    | True   | True     |
| True  | False | False  | False    | True   | True     |
| True  | True  | False  | True     | True   | False    |

## ❓ Quick Quiz (Write your answers before checking!)

```text
1. What is the result of not_gate(True)?
2. What is the result of and_gate(True, False)?
3. What is the result of or_gate(False, False)?
4. What is the result of xor_gate(True, True)?
5. Which gate returns True only when inputs are different?
```
