const timerDisplay = document.getElementById("timer");
const startBtn = document.getElementById("start");
const pauseBtn = document.getElementById("pause");
const resetBtn = document.getElementById("reset");
const breakModeBtn = document.getElementById("break-mode");
const darkModeBtn = document.getElementById("dark-mode");
const statusText = document.getElementById("status");
const alarmAudio = document.getElementById("alarm");

let figureTime = { default: 25 * 60, break: 5 };
let statusTextList = {
  default: "Time to Focus.",
  start: "🔔 Focus Mode: Stay on task!",
  end: "Time's up! Take a break.",
  pause: "⏸ Paused",
  reset: "🔁 Timer Reset",
  break: "☕️ Take a Break",
};

let time = figureTime.default; // 25 minute in seconds
let timer; // setInterval function
let isRunning = false; // flag
let isBreak = false;
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
  if (isRunning) return;
  isRunning = true;
  statusText.textContent = isBreak
    ? statusTextList.break
    : statusTextList.start;
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
  alarmAudio.play();
  //statusText.textContent = statusTextList.end;
  switchTimer();
}

function pauseTimer() {
  clearInterval(timer);
  isRunning = false;
  statusText.textContent = statusTextList.pause;
}

function resetTimer() {
  clearInterval(timer);
  isRunning = false;
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

startBtn.addEventListener("click", startTimer);
pauseBtn.addEventListener("click", pauseTimer);
resetBtn.addEventListener("click", resetTimer);
breakModeBtn.addEventListener("click", switchTimer);
darkModeBtn.addEventListener("click", setDarkMode);

setTimerText();
statusText.textContent = statusTextList.default;
