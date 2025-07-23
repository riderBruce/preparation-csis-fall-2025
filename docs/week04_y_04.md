## CSIS 2200 - Week 04 Day 4

### Topic: Types of Information Systems

### 🧠 Core Concepts to Learn Today

1. **Transactional Systems**

   - Handle day-to-day business transactions (e.g. sales, payroll, inventory).
   - Must be fast, reliable, and accurate.
   - Example: POS system at a grocery store.

2. **Functional Systems**

   - Support specific departments or functions like HR, finance, marketing.
   - Example: HR system managing employee records.

3. **Enterprise Systems**

   - Integrate all business processes into a unified system.
   - Example: ERP (Enterprise Resource Planning), CRM (Customer Relationship Management).
   - Benefit: reduces data redundancy and improves cross-department collaboration.

### 📘 Summary Table

| System Type   | Example                | Purpose                                 |
| ------------- | ---------------------- | --------------------------------------- |
| Transactional | POS, ATM               | Process routine transactions            |
| Functional    | HR System, Finance App | Support a specific business function    |
| Enterprise    | ERP, CRM               | Integrate functions across organization |

### 💡 Real-World Reflection Prompts

1. Have you ever interacted with a POS system or self-checkout machine?
2. Think about your previous job—did your department use any software tools to manage records?
3. What do you think are the benefits and risks of using one large enterprise system vs multiple small functional systems?

### 💻 Optional Coding Exercise

Since you miss pseudocode and coding practice, here’s a challenge:

> Imagine we are logging transactions in a basic inventory system. Write pseudocode that simulates processing a customer order and updating stock.

```plaintext
START
  INPUT product_id, quantity_requested
  IF quantity_requested <= stock[product_id] THEN
    stock[product_id] = stock[product_id] - quantity_requested
    DISPLAY "Order processed successfully."
  ELSE
    DISPLAY "Insufficient stock."
  ENDIF
END
```

Want to convert this into Python or JavaScript later?

### 🎯 Quick Quiz (for review)

1. What is the main goal of a transactional system?
2. Why might a company choose to implement an ERP system?
3. What could go wrong if departmental systems aren't integrated?

Let me know if you want to go deeper into ERP/CRM, or write some code examples based on today’s theory!
