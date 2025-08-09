## 📘 Day 2: JavaScript Operators, Comparisons, and Conditionals

### 🔑 Key Concepts

#### 1. Arithmetic Operators

```js
+, -, *, /, %, **
```

Used for mathematical calculations:

```js
let sum = 10 + 5; // 15
let mod = 10 % 3; // 1 (remainder)
let pow = 2 ** 3; // 8 (exponentiation)
```

#### 2. Assignment Operators

```js
=, +=, -=, *=, /=
```

Used to assign or update variables:

```js
let count = 1;
count += 2; // same as count = count + 2; => 3
```

#### 3. Comparison Operators

```js
>, <, >=, <=, ==, ===, !=, !==
```

`===` checks for **strict equality** (value + type), `==` does loose equality:

```js
5 == "5"; // true
5 === "5"; // false
```

#### 4. Logical Operators

```js
&& (and), || (or), ! (not)
```

Used for combining boolean expressions:

```js
let age = 20;
if (age > 18 && age < 30) {
  console.log("Young adult");
}
```

#### 5. Conditionals

```js
if, else if, else
```

```js
let temp = 25;
if (temp > 30) {
  console.log("Hot");
} else if (temp > 20) {
  console.log("Warm");
} else {
  console.log("Cold");
}
```

#### 6. switch Statement

```js
let day = 2;
switch (day) {
  case 1:
    console.log("Monday");
    break;
  case 2:
    console.log("Tuesday");
    break;
  default:
    console.log("Other day");
}
```

#### 7. Ternary Operator

```js
let age = 18;
let result = age >= 18 ? "Adult" : "Minor";
```

---

### 🧪 Practice Ideas

1. Write a function that returns a letter grade based on score (A, B, C, D, F)

```js
function checkLetterGrade(score) {
  if (score >= 90) return "A";
  if (score >= 80) return "B";
  if (score >= 70) return "C";
  if (score >= 60) return "D";
  return "F";
}
```

2. Use a `switch` to return month names from 1 to 12

```js
function switthMonthNames(num) {
  switch (num) {
    case 1:
      return "January";
    case 2:
      return "February";
    case 3:
      return "March";
    case 4:
      return "April";
    case 5:
      return "May";
    case 6:
      return "June";
    case 7:
      return "July";
    case 8:
      return "August";
    case 9:
      return "September";
    case 10:
      return "October";
    case 11:
      return "November";
    case 12:
      return "December";
    default:
      return "Maybe you are not on Earth.";
  }
}
```

3. Try chaining logical operators

```js
let a = true;
let b = 0;
let result = !(a || b) ? "true" : "false";
```

4. enum 

```js
const Colors = Object.freeze({
  RED: "red",
  GREEN: "green",
  BLUE: "blue",
});
console.log(Colors.RED);
const Status = {
  SUCCESS: Symbol("success"),
  ERROR: Symbol("error"),
  LOADING: Symbol("loading"),
};
console.log(Status.SUCCESS);
```
