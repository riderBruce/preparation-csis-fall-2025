# 📅 Day 6: JavaScript Forms & Validation (Continued)

### ✅ Topics for Today

- `blur` event for real-time feedback (on field exit)
- Creating **modular validation functions**
- Centralized error collection & display
- Using `e.preventDefault()` correctly
- Filtering out falsy messages with `.filter()`
- Optional Bonus: Reset + Success display

---

### 🧠 Mini Checklist

- ***

### 🧪 Suggested Practice Tasks

1. **Refactor** your validation code to have individual functions:
   - `validateName()`, `validateEmail()`, `validatePassword()`
2. **Add blur event** listeners for each input:

```js
input.addEventListener("blur", validateInputs);
```

3. **Optional Challenge:** Add a green border for valid fields ✅
4. **Optional Challenge:** Show success checkmark near fields 🟢

---

### 📝 Journal Prompt

- What made validation easier today?
- What still feels difficult or annoying?
- How is JS validation different from HTML5's built-in validation?
- Would you prefer using vanilla JS or a library like jQuery or React next time?
