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
    removeBtn.addEventListener("click", e => {
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