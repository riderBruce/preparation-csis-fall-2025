# 📘 Day 5 – Inheritance & Polymorphism

---

## 💪 Goal

Explore **Inheritance & Polymorphism**:

- Build `UndergraduateStudent`, `GraduateStudent`, or even `InternationalStudent`.
- Use polymorphism with `GetDetails()` and maybe even file output formatting.
- Think about replacing `List<Student>` with `List<BaseStudent>`.

## 📦 New Concepts

### ✅ 1. From Flat Class to Family Tree 👨‍👩‍👧‍👦

We’ve been working with a single `Student` class. Today, we prepare to create **a hierarchy**:

- `Student` becomes the base class.
- We'll introduce derived types like `UndergraduateStudent` and `GraduateStudent`.

I learned how to:

- Use the `:` syntax to inherit from a base class.
- Use `virtual` and `override` to enable polymorphism.

---

### ✅ 2. The Power of `virtual`, `override`, and `new`

- `virtual`: Declares that a method can be overridden.
- `override`: Actually replaces a base method in the child class.
- `new`: Hides the base class method with a new implementation.

This allows methods like `GetDetails()` to behave differently depending on the type of student. It's like giving each type its own voice 🗣️!

---

## 💪 Task

### ✅ 1. Define Base and Derived Classes

- Create a base class: Person

- Move common properties (Name, Age) to Person

- Inherit Student from Person

- Add a new class like Teacher to show multiple derived types

### ✅ 2. Use Virtual and Override

- Make GetDetails() in Person a virtual method

- Override GetDetails() in Student and Teacher

### ✅ 3. Polymorphism in Action

- Create a List<Person> and store both students and teachers

- Call GetDetails() in a loop and observe polymorphic behavior

### ✅ 4. Optional Enhancements

- Add interface like IDescribable

- Try as and is patterns to check types at runtime
