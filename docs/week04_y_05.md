# CSIS 2200 - Week 04 Day 5

## Topic: Quality of Information & Decision Making

### 📺 YouTube Suggestions

- What is Data Quality?
- Why Information Quality Matters?

### 🎯 Learning Objectives

- Understand the characteristics of **high-quality information**.
- Learn how **information quality impacts decision-making**.
- Identify **real-world consequences** of poor information.
- Practice evaluating information quality using a checklist.

### 📘 Key Concepts

| Attribute    | Meaning                                            |
| ------------ | -------------------------------------------------- |
| Accuracy     | Is the information correct and reliable?           |
| Completeness | Is anything missing?                               |
| Consistency  | Is the data consistent across sources and time?    |
| Timeliness   | Is it up-to-date when decisions are made?          |
| Relevance    | Is it appropriate and useful for the task at hand? |

### 🔎 Real-World Reflection

1. Have you ever made a bad decision because of missing or wrong information?
2. What are some examples in business where poor data quality caused problems?
3. Think about one system (an app, a report, or a dashboard) you use — how would you improve the **quality of its information**?

### 🧠 Activity – Evaluate Information Quality

Pick one example (a news article, dashboard, or a spreadsheet you’ve used) and answer:

- Is the data **complete**?
- Is it **accurate** and **up-to-date**?
- Can you **verify the source**?
- Does it help you make a clear decision?

### 💻 Bonus Coding (Optional)

Let’s simulate a quality check with some basic JavaScript:

```js
const data = {
  name: "Customer A",
  address: "",
  email: "customer@example.com",
  date: "2023-01-01",
};

function checkQuality(data) {
  const issues = [];
  if (!data.name) issues.push("Missing name");
  if (!data.address) issues.push("Missing address");
  const outdated = new Date(data.date) < new Date("2024-01-01");
  if (outdated) issues.push("Outdated information");

  return issues.length > 0 ? issues : ["Data looks good!"];
}

console.log(checkQuality(data));
```
