# 📅 Week 6 – Day 5: Responsive Design & Media Queries

### 🎯 Today's Goals

- Understand how **media queries** adapt layouts to different screen sizes
- Learn syntax and best practices for media queries
- Combine **Flexbox** and **Grid** with media queries for responsive layouts
- Explore common breakpoints for mobile, tablet, and desktop
- Build a responsive landing page

---

### 📐 Media Query Basics

#### Syntax:

```css
@media (max-width: 768px) {
  .container {
    flex-direction: column;
  }
}
```

- `max-width`: applies when screen width is _less than or equal to_ the value
- `min-width`: applies when screen width is _greater than or equal to_ the value

#### Common Breakpoints:

```css
/* Mobile */
@media (max-width: 480px) {
}
/* Tablet */
@media (max-width: 768px) {
}
/* Desktop */
@media (min-width: 1024px) {
}
```

---

### 🧩 Practice Exercise

Build a responsive layout with:

- A header with logo and nav links
- A two-column layout for desktop (sidebar + content)
- A single-column layout for mobile

---

### 📦 Bonus Practice Ideas

- Responsive **card layout** using `flex-wrap`
- Switch from **grid** to **stacked layout** using `display: block` in media queries
- Add hamburger menu using simple JS toggle + media query

---

Let me know when you're ready to begin today's coding challenge!
