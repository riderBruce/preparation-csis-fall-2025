const timerDisplay = document.getElementById("timer");
const startBtn = document.getElementById("start");
const pauseBtn = document.getElementById("pause");
const resetBtn = document.getElementById("reset");
const statusText = document.getElementById("status");

let time = 25 * 60; // 25 minutes in seconds
let timer;
let isRunning = false;

function updateDisplay() {
  const minutes = String(Math.floor(time / 60)).padStart(2, "0");
  const seconds = String(time % 60).padStart(2, "0");
  timerDisplay.textContent = `${minutes}:${seconds}`;
}

function startTimer() {
  if (isRunning) return;
  isRunning = true;
  statusText.textContent = "🔔 Focus Mode: Stay on task!";
  timer = setInterval(() => {
    time--;
    updateDisplay();
    if (time === 0) endTimer();
  }, 1000);
}

function endTimer() {
  clearInterval(timer);
  isRunning = false;
  statusText.textContent = "Time's up! Take a break.";
}

function pauseTimer() {
  clearInterval(timer);
  isRunning = false;
  statusText.textContent = "⏸ Paused";
}

function resetTimer() {
  clearInterval(timer);
  time = 25 * 60;
  updateDisplay();
  isRunning = false;
  statusText.textContent = "🔁 Timer Reset";
}

// Event Listeners
startBtn.addEventListener("click", startTimer);
pauseBtn.addEventListener("click", pauseTimer);
resetBtn.addEventListener("click", resetTimer);

// Initialize display
updateDisplay();
statusText.textContent = "⏱ Ready to focus?";


const importInput = document.getElementById("import-json");
const importBtn = document.getElementById("import-btn");

importBtn.addEventListener("click", () => {
  importInput.click();
})

importInput.addEventListener("change", readJSONLogFile);

function readJSONLogFile(e) {
  const file = e.target.files[0];
  if (!file) return;
  const reader = new FileReader();
  reader.onload = (e) => {
    try {
      const loadedLogs = JSON.stringify(e.target.result);
      if (!Array.isArray(loadedLogs)) throw new Error;
      // update
      logs = [...logs, ...loadedLogs];
      localStorage.setItem("logs", JSON.stringify(logs));
      loadedLogs.forEach((entry) => {
        if (entry.type === "focus") {
          sessionLog.focus += 1;
        } else if (entry.type === "break") {
          sessionLog.break += 1;
        };
      });
      localStorage.setItem("focus", sessionLog.focus);
      localStorage.setItem("break", sessionLog.break);
      //refresh
      viewSessionLog();
      viewToHistory();
  } catch (error) {
    console.error("failed :", error);
  };

  reader.readAsText(file);
  }
}