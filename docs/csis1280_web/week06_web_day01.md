# 📘 Week 6 – Day 1: Final HTML & CSS Review

🗓️ August 2
🎯 Focus: HTML semantics + CSS positioning + layout practice

---

## 🧠 Topics to Review

### ✅ HTML Semantics

- `<header>`, `<nav>`, `<main>`, `<section>`, `<article>`, `<aside>`, `<footer>`
- Importance of semantic tags for accessibility and SEO
- HTML5 Doctype & page structure

### ✅ CSS Fundamentals

- Selectors: `tag`, `.class`, `#id`, `*`, `:hover`, `:nth-child()`
- Box Model: `margin`, `border`, `padding`, `content`
- Display: `block`, `inline`, `inline-block`, `flex`, `grid`
- Positioning: `relative`, `absolute`, `fixed`, `sticky`
- Media Queries basics

---

## 💻 Hands-On Practice

### ✅ Mini Project: Simple Blog Page

Create a 2-column responsive layout:

- Left column: Blog entries using `<article>`
- Right column: Sidebar with author info and navigation

Includes:

- `<header>` with site title
- `<nav>` bar with anchor links
- CSS Flexbox or Grid
- Sticky header or sidebar (optional)

---

## 🔧 Starter Template (HTML)

```html
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>My Simple Blog</title>
    <link rel="stylesheet" href="style.css" />
  </head>
  <body>
    <header>
      <h1>Welcome to My Blog</h1>
      <nav>
        <a href="#">Home</a>
        <a href="#">About</a>
      </nav>
    </header>
    <main>
      <section class="content">
        <article>
          <h2>Day 1 Reflection</h2>
          <p>This is a sample article entry with HTML5 semantic tags.</p>
        </article>
      </section>
      <aside class="sidebar">
        <h3>About Me</h3>
        <p>Short bio here.</p>
      </aside>
    </main>
    <footer>
      <p>&copy; 2025 My Blog</p>
    </footer>
  </body>
</html>
```

## 🎨 Starter Template (CSS)

```css
* {
  box-sizing: border-box;
}
body {
  font-family: sans-serif;
  margin: 0;
  line-height: 1.6;
}
header,
footer {
  background-color: #333;
  color: white;
  padding: 10px;
  text-align: center;
}
nav a {
  color: white;
  margin: 0 10px;
  text-decoration: none;
}
main {
  display: flex;
  padding: 20px;
}
.content {
  flex: 3;
  margin-right: 20px;
}
.sidebar {
  flex: 1;
  background-color: #f4f4f4;
  padding: 10px;
}
@media (max-width: 768px) {
  main {
    flex-direction: column;
  }
}
```

## 📝 Journal Prompt (End of Day)

- What did I review today about HTML and CSS?
- What semantic tags or layout ideas did I rediscover?
- sDid I try the mini-project? What worked well or challenged me?
