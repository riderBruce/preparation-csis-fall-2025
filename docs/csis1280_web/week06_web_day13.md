# 🧩 Day 3: Destructuring & Spread/Rest

### 🔍 Object Destructuring

```js
const person = {
  name: "Alice",
  age: 30,
  city: "New York",
};

const { name, age } = person;
console.log(name); // Alice
console.log(age); // 30
```

### 🔍 Array Destructuring

```js
const colors = ["red", "green", "blue"];

const [first, second] = colors;
console.log(first); // red
console.log(second); // green
```

### 🔁 Spread Operator

- Used to **expand** arrays or objects

```js
const arr1 = [1, 2, 3];
const arr2 = [...arr1, 4, 5];
console.log(arr2); // [1, 2, 3, 4, 5]

const obj1 = { a: 1, b: 2 };
const obj2 = { ...obj1, c: 3 };
console.log(obj2); // { a: 1, b: 2, c: 3 }
```

### 📦 Rest Operator

- Used to **collect** remaining elements

```js
const [firstColor, ...otherColors] = ["red", "green", "blue"];
console.log(firstColor); // red
console.log(otherColors); // ["green", "blue"]

const { a, ...restObj } = { a: 1, b: 2, c: 3 };
console.log(restObj); // { b: 2, c: 3 }
```

### 🧠 Function Parameters with Destructuring

```js
function printUser({ name, age }) {
  console.log(`${name} is ${age} years old.`);
}

const user = { name: "Bob", age: 40, job: "engineer" };
printUser(user); // Bob is 40 years old.
```

---

### ✅ Practice Ideas

1. Destructure a person object into variables

```js
const person = {
  name: "son",
  gender: "male",
  age: 34,
  address: "seoul"
};
const {gender, address, age} = person;
console.log(gender);
console.log(address);
console.log(age);
```

2. Use rest operator on an array

```js
const coffees = ["americano", "latte", "juice", "milk"];
const [popularCoffee, ...otherBeverages] = coffees;
console.log(otherBeverages);
```

3. Use spread to merge two arrays

```js
let array1 = [2,3,4];
let array2 = [3,4,5];
let array3 = [...array1, ...array2];
console.log(array3);
```

4. Create a function that destructures a user object

```js
const user1 = {
  name: "Han",
  age: 33,
  gender: "male",
  nationality: "china",
};
function printUserFeature({gender, nationality}) {
  console.log(`The ${gender} from ${nationality}`)
}
printUserFeature(user1);
```
