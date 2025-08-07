const content = document.getElementById("content");
const highlighted = document.getElementById("highlighted");
const highlightBtn = document.querySelector(".btn-highlight");
const undoBtn = document.querySelector(".undo");
const clearBtn = document.querySelector(".clear-all");
const redBtn = document.querySelector(".color-selector.r");
const greenBtn = document.querySelector(".color-selector.g");
const blueBtn = document.querySelector(".color-selector.b");
const pickBtn = document.querySelector(".picker");

let currentColor = "d";
let highlightList = [];

highlightBtn.addEventListener("click", highlightText);

undoBtn.addEventListener("click", () => {
  if (highlightList.length > 0) {
    const lastMark = highlightList.pop();
    const textNode = document.createTextNode(lastMark.textContent);
    lastMark.replaceWith(textNode);
  }
});

clearBtn.addEventListener("click", () => {
  const text = content.textContent;
  content.textContent = text;
});

document.querySelectorAll(".color-selector").forEach((btn) => {
  btn.addEventListener("click", () => {
    const color = btn.dataset.color;
    changeColor(color);
    highlightText();
  });
});

pickBtn.addEventListener("change", (e) => {
  const color = e.target.value;
  updateCustomHighlightColor(color);
  highlightText();
});

function highlightText() {
  const selection = window.getSelection();

  if (selection.rangeCount > 0) {
    const range = selection.getRangeAt(0);
    const selectedText = selection.toString();
    if (selectedText.length > 0) {
      const mark = document.createElement("mark");
      mark.textContent = selectedText;

      if (currentColor.startsWith("#")) {
        mark.style.backgroundColor = currentColor;
      } else {
        mark.style.backgroundColor = "";
        mark.classList.add(currentColor);
      }

      range.deleteContents();
      range.insertNode(mark);
      highlightList.push(mark);
      selection.removeAllRanges();

      saveOnLocalStorage();
      viewHighlighted();
    }
  }
}

function changeColor(color) {
  const classes = Array.from(highlightBtn.classList);
  classes.forEach((cls) => {
    if (cls !== "btn-highlight") {
      highlightBtn.classList.remove(cls);
    }
  });
  if (color.startsWith("#")) {
    highlightBtn.style.backgroundColor = color;
  } else {
    highlightBtn.style.backgroundColor = "";
    highlightBtn.classList.add(color);
  }
  currentColor = color;
}

function selectCurrentColor() {
  return window.getComputedStyle(highlightBtn).backgroundColor;
}

function saveOnLocalStorage() {
  const data = highlightList.map((mark) => ({
    text: mark.textContent,
    color: mark.className,
  }));
  localStorage.setItem("marks", JSON.stringify(data));
}

function viewHighlighted() {
  highlighted.innerHTML = "";
  const recentHighlighted = highlightList.reverse();
  for (const entry of recentHighlighted) {
    const li = document.createElement("li");
    li.textContent = entry.textContent;

    if (entry.className) {
      li.className = entry.className;
    } else {
      li.style.backgroundColor = entry.style.backgroundColor;
    }

    highlighted.appendChild(li);
  }
}

function updateCustomHighlightColor(hexColor) {
  highlightBtn.classList.remove("r", "g", "b", "d");
  highlightBtn.style.backgroundColor = hexColor;
  currentColor = hexColor;
}
