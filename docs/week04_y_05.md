# CSIS 2200 - Week 04 Day 5

## Topic: Quality of Information & Decision Making

### 📺 YouTube Suggestions

- [What is Data Quality and Why is it Important?](https://www.youtube.com/watch?v=GWiiZWb69Sw)

  - Accuracy: Is the data correct?
  - Completeness: Is anything missing?
  - Consistency: Does it match across systems?
  - Currency: Is it up to date?
  - Conformity: Does it follow the right format?
  - No duplicates: Are there any repeated records?

- Why Information Quality Matters?
  - Make bad business strategies
  - Spend time and money fixing problems
  - Mess up reports or automation
  - Even break privacy laws (like GDPR or CCPA)

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

1. **Have you ever made a bad decision because of missing or wrong information?**  
   Yes. When I was working as a site financial manager in Yeosu, the ERP system showed that the site’s indirect budget was sufficient. Based on that information, we planned generous welfare activities for staff and workers.  
   However, it turned out that the budget input in the ERP system was incorrect. After spending a significant amount of the indirect budget, we realized the error and had to cancel plans like picnics and accommodations. It was a hard lesson about the importance of data accuracy.

2. **What are some examples in business where poor data quality caused problems?**  
   When integrating information across different systems, data such as department codes, employee IDs, or budget items must match.  
   If data is missing, duplicated, or mismatched, the integration can fail completely. I've seen projects delayed or abandoned because of poor-quality master data that made accurate reporting or decision-making impossible.

3. **Think about one system (an app, a report, or a dashboard) you use — how would you improve the *quality of its information*?**  
   I use map applications frequently — for finding restaurants, navigating routes, or getting a feel for a neighborhood. While the core map data is very helpful, the quality of user reviews is sometimes lacking.  
   Too few reviews or fake ones can lead to poor decisions.  
   I think a small incentive system — like a credibility or badge system for reviewers — could help improve both the quantity and quality of useful feedback.

### 🌱 Final Thought  

This reflection reminded me that good systems are not only about design and integration but also about the accuracy and trustworthiness of the data they carry.

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
