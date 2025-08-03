## 📅 Week 6 – Day 4: CSS Grid Fundamentals

### 🎯 Today's Goals

- Understand how **CSS Grid** works for 2D layouts (rows + columns)
- Learn to define grid structure with `grid-template-columns` and `grid-template-rows`
- Place grid items with `grid-column` and `grid-row`
- Explore `grid-gap`, `grid-area`, and `repeat()`
- Compare Grid vs Flexbox
- Build a responsive dashboard layout using Grid

---

### 🏢 Grid Basics

#### Enable Grid Layout:

```css
.container {
  display: grid;
}
```

#### Define Columns and Rows:

```css
.container {
  grid-template-columns: 1fr 1fr 1fr; /* 3 equal columns */
  grid-template-rows: auto auto;      /* 2 rows with auto height */
}
```

#### Add Gap Between Items:

```css
.container {
  gap: 20px; /* or use row-gap / column-gap */
}
```

---

### → Positioning Items

#### Span Multiple Columns/Rows:

```css
.item {
  grid-column: 1 / 3;  /* spans from column 1 to 2 (excludes 3) */
  grid-row: 1 / 2;     /* spans first row */
}
```

#### Named Areas:

```css
.container {
  grid-template-areas:
    "header header"
    "sidebar main"
    "footer footer";
}

.header  { grid-area: header; }
.sidebar { grid-area: sidebar; }
.main    { grid-area: main; }
.footer  { grid-area: footer; }
```

---

### 🖖 Practice Challenge

Build a simple dashboard layout with:

- A top navigation bar
- A sidebar
- A main content area
- A footer

```html
<div class="grid-container">
  <div class="header">Header</div>
  <div class="sidebar">Sidebar</div>
  <div class="main">Main</div>
  <div class="footer">Footer</div>
</div>
```

```css
.grid-container {
  display: grid;
  grid-template-areas:
    "header header"
    "sidebar main"
    "footer footer";
  grid-template-columns: 1fr 3fr;
  grid-template-rows: auto 1fr auto;
  min-height: 100vh;
  gap: 10px;
}

.header, .sidebar, .main, .footer {
  padding: 20px;
  background: #ffd86b;
  font-weight: bold;
  text-align: center;
}
```

---

### 🎨 Bonus Idea

Create a responsive **photo grid gallery**:

- Use `repeat(auto-fit, minmax(...))`
- Make it adapt to screen sizes

Let me know when you're ready to start building!

