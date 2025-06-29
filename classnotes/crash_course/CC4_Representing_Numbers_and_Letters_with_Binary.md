# 🧠 Representing Numbers and Letters with Binary  
_Crash Course Computer Science #4_

## 💾 Summary

This episode explains how computers store and represent numbers, letters, and other data using binary.

### 🔢 Binary Numbers
- **Binary** is similar to decimal—each digit’s position represents a value.
- A **bit** is a binary digit (`0` or `1`), and a **byte** is a group of 8 bits.
- **32-bit** systems can represent values up to ±2 billion.
- **64-bit** systems can handle up to ±9.2 quintillion, making them suitable for large-scale data like population or debt figures.

### 🔬 Floating Point Numbers
- Floating point numbers use 32 bits and are stored using **scientific notation**  
  _(e.g., `0.6259 × 10³`)_

### 🔡 Letters and Characters
- In the 1600s, **Francis Bacon** used 5-bit codes to represent the 26 letters of the alphabet.
- In **1963**, the **ASCII** standard (7 bits) was introduced, representing 128 characters.
- **Extended ASCII** expanded the range but still didn’t support all global languages.

### 🌍 The Need for Interoperability
- Countries developed incompatible **multi-byte encoding systems** to support their own characters.
- To solve this problem, **Unicode** was created in **1992**:
  - Uses **16 bits**
  - Includes global alphabets, math symbols, and even **emoji**!

### 🎨 Beyond Text
- Binary numbers can represent **sounds**, **colors**, **images**, and **video**.
- Underneath it all, computers store everything as long sequences of `1`s and `0`s.

---

## 🪞 Reflection

- It's amazing that everything from letters to HD video boils down to binary.
- I used to think data types like strings or floats were abstract—but now I see how they’re represented at the lowest level.
- This episode gave me a deeper appreciation for how computers universally understand information.

---

## 🧪 Quiz: Representing Numbers and Letters with Binary

Test your understanding with these short questions!

| #  | Question                                                                 | Your Answer         | Correct Answer        |
|----|--------------------------------------------------------------------------|---------------------|------------------------|
| 1  | What is a **bit**?                                                       |                     | A binary digit (0 or 1) |
| 2  | How many **bits** are in a **byte**?                                     |                     | 8                      |
| 3  | What does **8-bit color** represent?                                     |                     | 256 colors             |
| 4  | How many numbers can a **32-bit** integer represent?                     |                     | ±2 billion             |
| 5  | Why do we use **64-bit** numbers?                                        |                     | To store large numbers like population and debt |
| 6  | In a **floating point** number, what is the **significand**?            |                     | The main decimal number (e.g., 0.6259) |
| 7  | How many bits make up a **32-bit floating point** number?               |                     | 1 sign + 8 exponent + 23 significand |
| 8  | Who used **5 bits** to represent the alphabet in the 1600s?             |                     | Francis Bacon          |
| 9  | How many characters are in **ASCII**?                                    |                     | 128                    |
| 10 | What is **interoperability**?                                           |                     | The ability to exchange data universally |
| 11 | What was the problem with early **multi-byte encodings** like MOJIBAKE?|                     | They were incompatible between systems |
| 12 | When was **Unicode** introduced?                                        |                     | 1992                   |
| 13 | How many bits does Unicode use?                                         |                     | 16                     |
| 14 | What can binary encode besides numbers and letters?                     |                     | Sounds, images, video, emoji |
| 15 | Ultimately, what are all digital data made of?                          |                     | Sequences of 1s and 0s |

---

Feel free to fill in the answers yourself and quiz a friend!

```python
def ask(question, correct_answer):
    user = input(f"{question}\nYour answer: ").strip().lower()
    if user == correct_answer.lower():
        print("✅ Correct!\n")
    else:
        print(f"❌ Nope. Correct answer: {correct_answer}\n")

def binary_quiz():
    print("🧪 Binary Quiz – Representing Numbers and Letters\n")
    
    ask("1. What is a bit?", "A binary digit (0 or 1)")
    ask("2. How many bits are in a byte?", "8")
    ask("3. What does 8-bit color represent?", "256 colors")
    ask("4. How many numbers can a 32-bit integer represent?", "±2 billion")
    ask("5. Why do we use 64-bit numbers?", "To store large numbers like population and debt")
    ask("6. In a floating point number, what is the significand?", "The main decimal number (e.g., 0.6259)")
    ask("7. How many bits make up a 32-bit floating point number?", "1 sign + 8 exponent + 23 significand")
    ask("8. Who used 5 bits to represent the alphabet in the 1600s?", "Francis Bacon")
    ask("9. How many characters are in ASCII?", "128")
    ask("10. What is interoperability?", "The ability to exchange data universally")
    ask("11. What was the problem with early multi-byte encodings like MOJIBAKE?", "They were incompatible between systems")
    ask("12. When was Unicode introduced?", "1992")
    ask("13. How many bits does Unicode use?", "16")
    ask("14. What can binary encode besides numbers and letters?", "Sounds, images, video, emoji")
    ask("15. Ultimately, what are all digital data made of?", "Sequences of 1s and 0s")

# To run the quiz:
if __name__ == "__main__":
    binary_quiz()
```

---