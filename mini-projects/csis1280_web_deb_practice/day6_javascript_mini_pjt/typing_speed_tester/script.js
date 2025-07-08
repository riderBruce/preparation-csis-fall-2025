let startTime, endTime, intervalID;
const sampleText = document.getElementById("text-to-type").innerText;
const inputBox = document.getElementById("input-box");
const result = document.getElementById("result");
const clock = document.getElementById("clock");
inputBox.disabled = true;

function startTest() {
  inputBox.value = "";
  inputBox.disabled = false;
  inputBox.focus();
  result.textContent = "";
  startTime = new Date().getTime();

  intervalID = setInterval(updateClock, 10); // Update every 1 second
  updateClock(); // Run once immediately

  inputBox.addEventListener("input", checkTyping);
}

function checkTyping() {
  
  const enteredText = inputBox.value;
  if (enteredText === sampleText) {
    endTime = new Date().getTime();
    const timeTaken = (endTime - startTime) / 1000; // in seconds
    const wordCount = sampleText.split(" ").length;
    const wpm = Math.round((wordCount / timeTaken) * 60);

    result.innerHTML = `
      ✅ Well done! <br />
      Time taken: <strong>${timeTaken.toFixed(2)}</strong> seconds <br />
      Typing speed: <strong>${wpm}</strong> words per minute
    `;

    inputBox.disabled = true;
    clearInterval(intervalID);
  }
}

function updateClock() {
  const now = new Date().getTime();
  const timePass = (now - startTime)
  const minutes = String(Math.floor(timePass / 1000 / 60) % 60).padStart(2, "0");
  const seconds = String(Math.floor(timePass / 1000) % 60).padStart(2, "0");
  const milliseconds = String(Math.floor(timePass / 10) % 100).padStart(2, "0");

  const timeString = `${minutes}:${seconds}:${milliseconds}`;
  clock.textContent = timeString;
}

