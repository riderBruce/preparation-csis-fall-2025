## 📘 JavaScript `.filter()` Method – Journal Summary

### 🔎 What is `.filter()`?

The `.filter()` method is a built-in array method in JavaScript that returns a **new array** containing only the **elements that pass a specific test function**. It does not modify the original array.

---

### ✅ Syntax:

```js
const newArray = originalArray.filter(callbackFunction);
```

- ``: A function that returns `true` (to keep the element) or `false` (to exclude it).

---

### 🧪 Example 1: Filtering Even Numbers

```js
const numbers = [1, 2, 3, 4, 5, 6];
const evenNumbers = numbers.filter(num => num % 2 === 0);
console.log(evenNumbers); // [2, 4, 6]
```

---

### 🧪 Example 2: Removing Falsy Values

```js
const messages = ["Error 1", "", "Error 2", null, "Error 3"];
const cleaned = messages.filter(msg => msg);
console.log(cleaned); // ["Error 1", "Error 2", "Error 3"]
```

---

### 🧪 Example 3: Filtering Objects

```js
const users = [
  { name: "Alice", active: true },
  { name: "Bob", active: false },
  { name: "Carol", active: true },
];

const activeUsers = users.filter(user => user.active);
console.log(activeUsers);
// [{ name: "Alice", active: true }, { name: "Carol", active: true }]
```

---

### 🧩 Bonus: Combine with `.map()`

```js
const names = users
  .filter(user => user.active)
  .map(user => user.name);

console.log(names); // ["Alice", "Carol"]
```

---

### 🧠 Key Takeaways

| Feature             | Description                                         |
| ------------------- | --------------------------------------------------- |
| Purpose             | Keep only array elements that pass a test           |
| Returns             | A **new array**                                     |
| Removes             | Falsy values if the test checks for truthiness      |
| Often Combined With | `.map()`, `.reduce()`, etc. for data transformation |

---

### ✅ Real-Life Use Case

```js
const errors = [
    validateName(),
    validateEmail(),
    validatePassword()
].filter(msg => msg);
```

> This removes empty error messages and keeps only actual error messages.

---

Let me know if you want a mini project to practice `.filter()`!

