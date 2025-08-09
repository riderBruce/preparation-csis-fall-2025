function addTask() {
  // Get text -> Create li -> Add text in li
  const taskText = taskInput.value.trim();
  if (taskText === "") return;
  const li = document.createElement("li");
  li.textContent = taskText;
  // Event completed with CSS
  li.addEventListener("click", () => {
    li.classList.toggle("completed");
  });
  // Create btn -> Add text, class name, Event -> Add btn in li -> Add li in list
  const removeBtn = document.createElement("button");
  removeBtn.textContent = "x";
  removeBtn.className = "remove-btn";
  removeBtn.addEventListener("click", (e) => {
    e.stopPropagation();
    taskList.removeChild(li);
  });
  li.appendChild(removeBtn);
  taskList.appendChild(li);
  // clear input
  taskInput.value = "";
}

// flag
let isRunning = false;

function startTimer() {
  // valiadation
  if (isRunning) return;

  // adjust varables
  isRunning = true;
  isPause ? (isPause = false) : logCounter(); // not good, if side effect occur
  if (isPause) {
    isPause = false;
  } else {
    logCounter();
  }

  // view item on screen
  statusText.textContent = isBreak
    ? statusTextList.break
    : statusTextList.start;
  viewSessionLog();
  // set
  timer = setInterval(() => {
    time--;
    updateProgress();
    setTimerText();
    if (time === 0) endTimer();
  }, 1000);
}

function handleImport(event) {
  const file = event.target.files[0];
  if (!file) return;

  const reader = new FileReader();

  reader.onload = function (e) {
    try {
      const importedLogs = JSON.parse(e.target.result);

      // Validation
      if (!Array.isArray(importedLogs)) {
        throw new Error("Invalid JSON structure");
      }

      // Updates
      importedLogs.forEach((entry) => {
        if (entry.type === "focus") {
          sessionLog.focus += 1;
        } else if (entry.type === "break") {
          sessionLog.break += 1;
        }
      });
      localStorage.setItem("focus", sessionLog.focus);
      localStorage.setItem("break", sessionLog.break);

      logs = [...logs, ...importedLogs];
      localStorage.setItem("logs", JSON.stringify(logs));

      // Refreshes
      viewSessionLog();
      viewToHistory();

      alert("✅ Logs imported successfully!");
    } catch (error) {
      console.error("Import failed:", error);
      alert("❌ Failed to import logs.");
    }
  };

  reader.readAsText(file);
}

function downloadLogsAsJSON() {
  if (logs.length === 0) {
    alert("No logs to download.");
    return;
  }

  const blob = new Blob([JSON.stringify(logs, null, 2)], {
    type: "application/json",
  });
  const url = URL.createObjectURL(blob);
  const a = document.createElement("a");

  a.href = url;
  a.download = "pomodoro_logs.json";
  document.body.appendChild(a);
  a.click();
  document.body.removeChild(a);
  URL.revokeObjectURL(url);
}

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


