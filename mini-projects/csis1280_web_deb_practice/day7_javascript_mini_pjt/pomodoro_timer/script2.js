const timerDisplay = document.getElementById("timer");

const startBtn = document.getElementById("start");
const pauseBtn = document.getElementById("pause");
const resetBtn = document.getElementById("reset");
const breakModeBtn = document.getElementById("break-mode");
const darkModeBtn = document.getElementById("dark-mode");

const downloadBtn = document.getElementById("download-json");
const clearLogsBtn = document.getElementById("clear-logs");

const alarmAudio = document.getElementById("alarm");

const statusText = document.getElementById("status");
const logText = document.getElementById("session-log");
const logHistoryList = document.getElementById("log-history");

let figureTime = { default: 25 * 60, break: 5 * 60 };
let statusTextList = {
  default: "Time to Focus.",
  start: "🔔 Focus Mode: Stay on task!",
  end: "Time's up! Take a break.",
  pause: "⏸ Paused",
  reset: "🔁 Timer Reset",
  break: "☕️ Take a Break",
};

let sessionLog = {
  focus: Number(localStorage.getItem("focus") || 0),
  break: Number(localStorage.getItem("break") || 0),
};
let logs = JSON.parse(localStorage.getItem("logs")) || [];

let time = figureTime.default; // 25 minute in seconds
let timer; // setInterval function
let isRunning = false; // flag
let isBreak = false;
let isPause = false;
// let isDark = false;

function setDarkMode() {
  document.body.classList.toggle("dark-mode");
}

function setTimerText() {
  let minutes = String(Math.floor(time / 60)).padStart(2, "0");
  let seconds = String(Math.floor(time % 60)).padStart(2, "0");
  timerDisplay.textContent = `${minutes}:${seconds}`;
}

function updateProgress() {
  const percent = isBreak
    ? (time / figureTime.break) * 100
    : (time / figureTime.default) * 100;
  progressBar.style.width = `${percent}%`;
}

function startTimer() {
  // valiadation
  if (isRunning) return;
  // adjust varables
  isRunning = true;
  isPause ? (isPause = false) : logCounter();
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

function endTimer() {
  clearInterval(timer);
  isRunning = false;
  isPause = false;
  alarmAudio.play();
  //statusText.textContent = statusTextList.end;
  switchTimer();
}

function pauseTimer() {
  if (!isRunning) return;
  clearInterval(timer);
  isRunning = false;
  isPause = true;
  statusText.textContent = statusTextList.pause;
}

function resetTimer() {
  clearInterval(timer);
  isRunning = false;
  isPause = false;
  statusText.textContent = statusTextList.reset;
  time = isBreak ? figureTime.break : figureTime.default;
  setTimerText();
}

function switchTimer() {
  if (isRunning) return;
  isBreak = !isBreak;
  time = isBreak ? figureTime.break : figureTime.default;
  statusText.textContent = isBreak
    ? statusTextList.break
    : statusTextList.default;
  setTimerText();
}

function viewSessionLog() {
  logText.textContent = `Completed: 🎯 ${sessionLog.focus} focus / ☕️ ${sessionLog.break} break`;
}

function logCounter() {
  if (isBreak) {
    sessionLog.break += 1;
    localStorage.setItem("break", sessionLog.break);
    logs.push({ type: "break", time: new Date().toISOString() });
    localStorage.setItem("logs", JSON.stringify(logs));
  } else {
    sessionLog.focus += 1;
    localStorage.setItem("focus", sessionLog.focus);
    logs.push({ type: "focus", time: new Date().toISOString() });
    localStorage.setItem("logs", JSON.stringify(logs));
  }
  viewToHistory();
}

function viewToHistory() {
  logHistoryList.innerHTML = "";
  const recentLogs = logs.slice(-5).reverse();
  for (const entry of recentLogs) {
    const li = document.createElement("li");
    const time = new Date(entry.time).toLocaleTimeString();
    li.textContent = `${entry.type === "focus" ? "🎯" : "☕️"} ${
      entry.type
    } - ${time}`;
    logHistoryList.appendChild(li);
  }
}

function downloadLogsAsJSON() {
  if (logs.length === 0) {
    alert("No logs to download.");
    return;
  }

  const blob = new Blob([JSON.stringify(logs, null, 2)], {type: "application/json"});
  const url = URL.createObjectURL(blob);
  const a = document.createElement("a");

  a.href = url;
  a.download = "pomodoro_logs.json";
  document.body.appendChild(a);
  a.click();
  document.body.removeChild(a);
  URL.revokeObjectURL(url);
}

function clearLogs() {
  const confirmClear = confirm("Do you really want to clear all logs?");
  if (!confirmClear) return;
  // localStorage
  localStorage.removeItem("focus");
  localStorage.removeItem("break");
  localStorage.removeItem("logs");

  // Memory
  sessionLog = { focus: 0, break: 0 };
  logs = [];
  // Screen
  statusText.textContent = "Cleared.";
  logText.textContent = `Completed: 🎯 0 focus / ☕️ 0 break`;
  logHistoryList.innerHTML = "";
}

startBtn.addEventListener("click", startTimer);
pauseBtn.addEventListener("click", pauseTimer);
resetBtn.addEventListener("click", resetTimer);
breakModeBtn.addEventListener("click", switchTimer);
darkModeBtn.addEventListener("click", setDarkMode);
downloadBtn.addEventListener("click", downloadLogsAsJSON);
clearLogsBtn.addEventListener("click", clearLogs);

setTimerText();
statusText.textContent = statusTextList.default;
viewSessionLog();
