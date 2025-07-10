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