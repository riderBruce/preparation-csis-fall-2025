const highlightBtn = document.querySelector(".btn-highlight");
const redBtn = document.querySelector(".color-selector.r");
const greenBtn = document.querySelector(".color-selector.g");
const blueBtn = document.querySelector(".color-selector.b");
let currentColor = "d";
let highlightList = [];

highlightBtn.addEventListener("click", highlightText);
redBtn.addEventListener("click", () => {
  changeColor("r");
});
greenBtn.addEventListener("click", () => {
  changeColor("g");
});
blueBtn.addEventListener("click", () => {
  changeColor("b");
});

function highlightText() {
  const selection = window.getSelection();

  if (selection.rangeCount > 0) {
    const range = selection.getRangeAt(0);
    const selectedText = selection.toString();
    if (selectedText.length > 0) {
      const mark = document.createElement("mark");
      mark.textContent = selectedText;
      mark.classList.add(currentColor);

      range.deleteContents();
      range.insertNode(mark);
      
      selection.removeAllRanges();
    }
  }
}

function changeColor(color) {
  highlightBtn.classList.remove("d");
  highlightBtn.classList.remove("r");
  highlightBtn.classList.remove("g");
  highlightBtn.classList.remove("b");
  highlightBtn.classList.add(color);
  currentColor = color;
}

function colorSelector(color) {
  switch (color) {
    case "red":
      return "r";
    case "green":
      return "g";
    case "blue":
      return "b";
    default:
      return "Invalid color";
  }
}

function selectCurrentColor() {
  return window.getComputedStyle(highlightBtn).backgroundColor;
}
