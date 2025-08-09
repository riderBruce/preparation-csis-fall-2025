## 🧱 Day 2: Arrow Functions & Implicit Returns

### 🚀 Arrow Function Syntax

```js
// Regular function
function add(a, b) {
  return a + b;
}

// Arrow function (explicit return)
const add = (a, b) => {
  return a + b;
};

// Arrow function (implicit return)
const add = (a, b) => a + b;

// One parameter doesn't need parentheses
const square = x => x * x;

// No parameters
const sayHi = () => console.log("Hi!");
```

---

### ⚠️ When Not to Use Arrow Functions

Arrow functions **do not bind** their own `this`.

```js
const person = {
  name: "John",
  greet: () => {
    console.log(`Hi, I'm ${this.name}`); // "this" is not bound to person
  }
};

person.greet(); // Hi, I'm undefined
```

**Use regular functions** in methods or constructors when `this` is needed.

```js
const person = {
  name: "Jane",
  greet() {
    console.log(`Hi, I'm ${this.name}`);
  }
};

person.greet(); // Hi, I'm Jane
```

---

### 🧾 Returning Objects Implicitly

```js
// Wrap object in parentheses!
const getUser = () => ({ name: "Alice", age: 25 });
```

Otherwise JavaScript thinks you're opening a block:

```js
const getUser = () => {
  name: "Alice";
  age: 25;
}; // undefined
```

---

### ✅ Practice Ideas

1. Convert a traditional function to an arrow function.

```js
function thisFunction(parm) {...};
let thisFunction = parm => {...};
```

2. Use implicit return to return the square of a number.

```js
let getSquare = num => num * num;
```

3. Create an arrow function that returns an object.

```js
let getStudent = () => ({name:"Song", faculty:"Engineering"});
```

4. Demonstrate an arrow function **not** working with `this`, and fix it.

```js
const musicBox = {
  title: "Happy meal",
  singer: () => {`Michel sing ${this.title}`;},
};
const musicBox = {
  title: "Happy meal",
  singer() {`Michel sing ${this.title}`;},
};
```