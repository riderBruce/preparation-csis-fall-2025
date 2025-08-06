const highlightBtn = document.querySelector(".btn-highlight");

highlightBtn.addEventListener("click", highlightText);

function highlightText() {
  const selection = window.getSelection();

  if (selection.rangeCount > 0) {
    const range = selection.getRangeAt(0);
    const selectedText = selection.toString();
    if (selectedText.length > 0) {
      const mark = document.createElement("mark");
      mark.textContent = selectedText;

      range.deleteContents();
      range.insertNode(mark);
      selection.removeAllRanges();
    }
  }
}
