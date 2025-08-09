## 📋 Day 5: Array Methods Crash Course

### 🎯 Goal

- Understand and practice the most common JavaScript array methods for data transformation and querying.

---

### 1. Methods to Cover

#### `map()`

- Purpose: Transform each element in an array and return a new array.
- Example:
  ```js
  const numbers = [1, 2, 3];
  const doubled = numbers.map((num) => num * 2);
  console.log(doubled); // [2, 4, 6]
  ```

#### `filter()`

- Purpose: Return a new array with elements that pass a test.
- Example:
  ```js
  const nums = [5, 10, 15, 20];
  const over10 = nums.filter((num) => num > 10);
  console.log(over10); // [15, 20]
  ```

#### `reduce()`

- Purpose: Reduce an array to a single value.
- Example:
  ```js
  const arr = [1, 2, 3, 4];
  const sum = arr.reduce((total, num) => total + num, 0);
  console.log(sum); // 10
  ```

#### `find()`

- Purpose: Return the first element that matches a condition.
- Example:
  ```js
  const users = [{ id: 1 }, { id: 2 }, { id: 3 }];
  const user = users.find((u) => u.id === 2);
  console.log(user); // { id: 2 }
  ```

#### `some()`

- Purpose: Check if at least one element meets a condition.
- Example:
  ```js
  const hasEven = [1, 3, 5, 8].some((num) => num % 2 === 0);
  console.log(hasEven); // true
  ```

#### `every()`

- Purpose: Check if all elements meet a condition.
- Example:
  ```js
  const allPositive = [2, 4, 6].every((num) => num > 0);
  console.log(allPositive); // true
  ```

---

### 2. Practice Tasks

- **Task 1:** Convert an array of temperatures in Celsius to Fahrenheit using `map()`.

  ```js
  let celsiuses = [20, 30, 40];
  let fahrenheits = celsiuses.map(c => c * 9 / 5 + 32);
  console.log(fahrenheits);
  ```

- **Task 2:** From a list of names, get only those starting with the letter 'A' using `filter()`.

  ```js
  let names = ["Anthony", "Adel", "Tommy"];
  let filtered = names.filter(name => name.toLowerCase().startsWith("a"));
  console.log(filtered);
  ```

- **Task 3:** Find the total price from an array of product prices using `reduce()`.

  ```js
  let prices = [30, 20, 100];
  let sum = prices.reduce((acc, price) => acc + price, 0);
  console.log(sum);
  ```

- **Task 4:** Find the first product with a price greater than \$50 using `find()`.

  ```js
  let prices = [30, 60, 70, 100];
  let firstPriceOver50 = prices.find(price => price > 50);
  console.log(firstPriceOver50);
  ```

- **Task 5:** Check if any product is out of stock using `some()`.

  ```js
  let stocks = {apple: 0, banana: 50, cherry: 100};
  let isSomeOutOfStock = Object.values(stocks).some(quantity => quantity === 0);
  console.log(isSomeOutOfStock);
  ```

- **Task 6:** Check if all students passed an exam (score >= 60) using `every()`.

  ```js
  let students = [
    {name: "John", score: 60,},
    {name: "Ron", score: 70,},
    {name: "Jane", score: 56,},
  ]
  let isAllPassed = students.every(student => student.score >= 60);
  console.log(isAllPassed);
  ```
