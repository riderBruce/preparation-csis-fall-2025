# 🔃 Day 4: Template Literals & Default Parameters

### 🧵 Template Literals (Backticks)

- Introduced in ES6 using backticks: `` `like this` ``
- Allow **multi-line strings**
- Allow **interpolation** using `${}`

```js
const name = "Alex";
const greeting = `Hello, ${name}!`;
console.log(greeting); // Hello, Alex!
```

```js
const story = `Once upon a time,
There was a coder who loved JavaScript.`;
console.log(story);
```

### 🧩 Default Parameters

- Functions can have default values for parameters

```js
function greet(name = "Guest") {
  console.log(`Hello, ${name}!`);
}

greet(); // Hello, Guest!
greet("Alice"); // Hello, Alice!
```

### ✨ Tagged Template Literals (Optional Advanced)

- Useful for **custom formatting**

```js
function tag(strings, value) {
  return `${strings[0]}**${value.toUpperCase()}**${strings[1]}`;
}

const name = "alex";
const result = tag`Hello, ${name}!`;
console.log(result); // Hello, **ALEX**!
```

---

### ✅ Practice Ideas

1. Use template literals to build a personalized welcome message

```js
function sayHi(name) {
  console.log(`Hi. ${name}`);
}
console.log(sayHi("ChatGPT"));
```

2. Create a function that has a default parameter

3. Try a function with multiple default parameters

```js
function add(acc = 0, num = 0) {
  return acc + num;
}
console.log(add());
console.log(add(3));
console.log(add(3, 5));
```

4. (Optional) Use a tagged template to transform input

```js
function tagSample(strings, ...values) {
  return strings.reduce((acc, str, i) => {
    return acc + str + (values[i] ? `<h1>${values[i]}</h1>` : "");
  }, "");
}
const nation = "US";
const anotherNation = "Canada";
const result = tagSample`Do you think that ${nation} will connect with ${anotherNation}?`;
console.log(result);
```
