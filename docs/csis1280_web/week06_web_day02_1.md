## 📅 Week 6 – Day 2: CSS Box Model and Layout

### 🎯 Today's Goals

- Understand the **CSS box model** in depth
- Practice using **margin**, **border**, **padding**, and **content**
- Explore **box-sizing**, **overflow**, and **display** properties
- Learn about **positioning**: static, relative, absolute, fixed, sticky
- Use **z-index** and layering

---

### 📦 CSS Box Model Breakdown

Each HTML element is a box with 4 layers:

```
| Margin |
| Border |
| Padding |
| Content |
```

- `content`: The actual content like text or images
- `padding`: Space between content and border
- `border`: Line around the element
- `margin`: Space outside the element

```css
.box {
  width: 200px;
  padding: 20px;
  border: 5px solid black;
  margin: 30px;
}
```

Use `box-sizing: border-box` to include padding and border in total width.

---

### 🧭 Positioning and Layout

#### `position` values:

- `static`: default
- `relative`: moves element relative to normal position
- `absolute`: relative to nearest positioned ancestor
- `fixed`: stays in same place even when scrolling
- `sticky`: sticks to top when scrolling past it

```css
.banner {
  position: sticky;
  top: 0;
  background-color: yellow;
}
```

#### `z-index`

- Controls stacking order (higher is in front)

```css
.modal {
  position: absolute;
  z-index: 1000;
}
```

---

### 🧪 Practice Challenge

Build a layout with 3 boxes:

- One with margin and padding
- One with `absolute` positioning
- One with `z-index` layered on top

```html
<div class="box1">Box 1</div>
<div class="box2">Box 2</div>
<div class="box3">Box 3</div>
```

```css
.box1 {
  margin: 30px;
  padding: 20px;
  background: lightblue;
}
.box2 {
  position: absolute;
  top: 100px;
  left: 100px;
  background: coral;
}
.box3 {
  position: absolute;
  top: 120px;
  left: 120px;
  background: gold;
  z-index: 2;
}
```

---

### 📌 Mini Project Idea

Create a simple landing page:

- Header (sticky)
- Sidebar (fixed or absolute)
- Main content with padding and margin
- Footer at the bottom

Let me know when you’re ready to begin the exercises or want help building the layout!

