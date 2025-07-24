# CSIS 2200 - Week 04 Day 4

## Topic: Types of Information Systems

### ✏️ Youtube Videos

- [Types of Information Systems (TPS, MIS, and DSS)](https://www.youtube.com/watch?v=nQ4Q3iN7TMM)
- [Types of Information Systems](https://www.youtube.com/watch?v=5hMhvDG35eA)

  - TPS : Transaction Processing System
  - MIS : Management Information System
  - DSS : Decision Supporting System

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
