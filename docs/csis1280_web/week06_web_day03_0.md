## 📅 Week 6 – Day 3: CSS Flexbox Mastery

### 🎯 Today's Goals

- Understand the purpose and benefits of **Flexbox**
- Practice setting up **flex containers** and **flex items**
- Learn properties like `justify-content`, `align-items`, `flex-direction`, and `flex-wrap`
- Build flexible, responsive layouts using Flexbox

---

### 🏢 Flexbox Basics

Flexbox is a one-dimensional layout system that makes it easier to design flexible and responsive layouts.

#### Enable Flexbox:

```css
.container {
  display: flex;
}
```

#### Control Direction:

```css
.container {
  flex-direction: row;      /* default */
  flex-direction: column;   /* vertical stacking */
}
```

#### Spacing Items:

```css
.container {
  justify-content: flex-start;   /* default */
  justify-content: center;
  justify-content: space-between;
  justify-content: space-around;
  justify-content: space-evenly;
}
```

#### Align Items Vertically:

```css
.container {
  align-items: stretch;   /* default */
  align-items: center;
  align-items: flex-start;
  align-items: flex-end;
  align-items: baseline;
}
```

#### Wrap Items:

```css
.container {
  flex-wrap: wrap;
}
```

#### Target Individual Items:

```css
.item {
  flex: 1; /* grows to fill space */
  align-self: flex-start;
}
```

---

### 🔮 Practice Challenge

Build a simple 3-column layout that:

- Centers items horizontally and vertically
- Adapts to screen size (wraps on small screens)

```html
<div class="container">
  <div class="box">1</div>
  <div class="box">2</div>
  <div class="box">3</div>
</div>
```

```css
.container {
  display: flex;
  justify-content: center;
  align-items: center;
  flex-wrap: wrap;
  min-height: 100vh;
  gap: 20px;
}

.box {
  background: #ffd86b;
  width: 150px;
  height: 150px;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 2rem;
  font-weight: bold;
}
```

---

### 📉 Mini Project Idea

Create a **responsive photo gallery** using Flexbox:

- Display image thumbnails in rows
- Wrap automatically on smaller screens
- Add hover effects and spacing

Let me know when you're ready to start coding or if you want a challenge version of this gallery!

