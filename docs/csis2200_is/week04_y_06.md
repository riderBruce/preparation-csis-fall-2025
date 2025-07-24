# CSIS 2200 - Week 04 Day 6

## 📌 Topic: Data Modeling & System Components

### 🧠 Key Concepts to Learn

1. **System Components**

   - People
   - Hardware
   - Software
   - Data
   - Networks
     > These components work together to support the business.

2. **Data Modeling**

   - **Entity**: An object or concept (e.g., Customer, Product).
   - **Attribute**: A property of an entity (e.g., Name, Email).
   - **Relationship**: How entities are connected (e.g., A Customer places an Order).

3. **Entity-Relationship Diagram (ERD)**
   - A visual representation of data relationships.
   - Basic symbols: Rectangles (Entities), Ovals (Attributes), Diamonds (Relationships).

### 📘 Study Prompt

- Watch: [ER Diagram Tutorial | Learn ERD step by step](https://www.youtube.com/watch?v=QpdhBUYk7Kk)

### 🧪 Optional Coding Challenge

Let’s simulate an entity and relationship in JavaScript:

```javascript
const customer = {
  id: 101,
  name: "Alice",
  email: "alice@example.com",
};

const orders = [
  { orderId: 1, customerId: 101, item: "Keyboard" },
  { orderId: 2, customerId: 101, item: "Monitor" },
];

function getOrdersByCustomer(customerId) {
  return orders.filter((order) => order.customerId === customerId);
}

console.log(getOrdersByCustomer(customer.id));
```

### 💬 Reflection Questions

1. Can you think of a real-world example where systems components (like people and software) worked together effectively?
2. Have you ever seen an ER diagram before? Where or how?
3. Why is it important to model data before building a system?

### 📝 Mini Exercise

Draw a simple ERD (on paper or tool) for a Library System:

- Entities: Book, Member, Loan
- Attributes: (e.g., Book → title, author)
- Relationships: A Member borrows a Book
