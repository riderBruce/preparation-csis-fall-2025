# 📐 CSS Grid Cheatsheet

## 🎯 Overview

CSS Grid is a powerful 2D layout system for web design. It allows you to create complex layouts with rows and columns.

---

## 🔧 Enabling Grid

```css
.container {
  display: grid;
}
```

---

## 📏 Define Columns and Rows

```css
.container {
  grid-template-columns: 1fr 1fr 1fr; /* 3 equal columns */
  grid-template-rows: auto auto; /* 2 rows with auto height */
}
```

- `fr` = fraction unit (portion of available space)
- `auto` = adapts to content height

---

## 📐 Gap Between Items

```css
.container {
  gap: 20px; /* row + column gap */
  row-gap: 10px;
  column-gap: 15px;
}
```

---

## 📌 Position Items

### Span Multiple Grid Lines

```css
.item {
  grid-column: 1 / 3; /* spans from col 1 to 2 */
  grid-row: 1 / 2;
}
```

### Named Grid Areas

```css
.container {
  grid-template-areas:
    "header header"
    "sidebar main"
    "footer footer";
  grid-template-columns: 1fr 3fr;
  grid-template-rows: auto 1fr auto;
}

.header {
  grid-area: header;
}
.sidebar {
  grid-area: sidebar;
}
.main {
  grid-area: main;
}
.footer {
  grid-area: footer;
}
```

---

## 🎨 Responsive Grid Gallery

```css
.gallery {
  display: grid;
  gap: 10px;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
}
```

---

## 🔁 Bonus Keywords

- `repeat(n, ...)`: Repeat a value
- `minmax(min, max)`: Minimum and maximum range for column/row size
- `auto-fit` vs `auto-fill`: Fit vs fill available space
- `place-items: center`: Center content in both axes

---

## 🧱 Grid vs Flexbox

| Feature       | Grid                   | Flexbox              |
| ------------- | ---------------------- | -------------------- |
| Axis          | 2D (rows + columns)    | 1D (row _or_ column) |
| Best For      | Layout structure       | Component alignment  |
| Overlap Items | Yes (grid lines/areas) | No                   |

---

## Demo Template

```html
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>CSS Grid Dashboard</title>
    <style>
      * {
        box-sizing: border-box;
        margin: 0;
        padding: 0;
      }

      body {
        font-family: Arial, sans-serif;
        background-color: #f2f2f2;
      }

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
        padding: 20px;
      }

      .grid-container > div {
        padding: 20px;
        background-color: #ffefc3;
        border-radius: 8px;
        font-weight: bold;
        text-align: center;
      }

      .header {
        grid-area: header;
      }
      .sidebar {
        grid-area: sidebar;
      }
      .main {
        grid-area: main;
      }
      .footer {
        grid-area: footer;
      }

      @media (max-width: 768px) {
        .grid-container {
          grid-template-areas:
            "header"
            "main"
            "sidebar"
            "footer";
          grid-template-columns: 1fr;
        }
      }
    </style>
  </head>
  <body>
    <div class="grid-container">
      <div class="header">Header</div>
      <div class="sidebar">Sidebar</div>
      <div class="main">Main Content</div>
      <div class="footer">Footer</div>
    </div>
  </body>
</html>
```
