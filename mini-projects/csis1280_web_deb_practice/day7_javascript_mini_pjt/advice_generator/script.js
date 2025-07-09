const adviceText = document.getElementById("advice-text");
const button = document.getElementById("get-advice");

// button.addEventListener("click", () => {
//   fetch("https://api.adviceslip.com/advice")
//     .then(res => res.json())
//     .then(data => {
//       adviceText.textContent = `"${data.slip.advice}"`;
//     })
//     .catch(error => {
//       adviceText.textContent = "⚠️ Failed to fetch advice.";
//       console.error(error);
//     });
// });

const spinner = document.getElementById("spinner");
const url = "https://api.adviceslip.com/advice"
button.addEventListener("click", setAdvice);

// async function setAdvice() {
//   try {
//     adviceText.textContent = "";
//     spinner.classList.remove("hidden");
//     await new Promise(resolve => setTimeout(resolve, 1600));
//     const res = await fetch(url);
//     if (!res.ok) throw new Error("Network response was not ok!")
//     const data = await res.json();
//     adviceText.textContent = `"${data.slip.advice}"`;
//   } catch (error) {
//     adviceText.textContent = "Failed to fetch advice.";
//     console.error(error);
//   } finally {
//     spinner.classList.add("hidden");
//   }
// }


const historyList = document.getElementById("history");

function addToHistory(advice) {
  const li = document.createElement("li");
  li.textContent = advice;
  historyList.prepend(li);
}

async function setAdvice() {
  try {
    adviceText.textContent = "";
    spinner.classList.remove("hidden");

    const res = await fetch(url);
    if (!res.ok) throw new Error("Network response was not ok!");

    const data = await res.json();
    const advice = data.slip.advice;
    adviceText.textContent = `"${advice}"`;

    addToHistory(advice);
  } catch (error) {
    adviceText.textContent = "Failed to fetch advice.";
    console.error(error);
  } finally {
    spinner.classList.add("hidden");
  }
}