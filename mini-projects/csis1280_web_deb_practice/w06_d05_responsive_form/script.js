const form = document.getElementById("contact-form");
const errorMsgs = document.getElementById("errorMsgs");
const toastMsg = document.getElementById("toastMsg");
const darkModeBtn = document.getElementById("darkModeBtn");

form.addEventListener("input", validateForm);

form.addEventListener("submit", (e) => {
  e.preventDefault();
  var result = validateForm();
  if (result) {
    form.reset();
    toastMsg.innerHTML = "🚀 Saved.";
    setTimeout(() => {toastMsg.textContent = "";}, 3000);
  }
});

darkModeBtn.addEventListener("click", () => {
    document.body.classList.toggle("dark-mode");
})

function validateForm() {
  const name = form.name.value.trim();
  const email = form.email.value;
  const message = form.message.value;

  let errors = [
    validateName(name),
    validateEmail(email),
    validateMessage(message),
  ].filter((msg) => msg);
  if (errors.length > 0) {
    errorMsgs.innerHTML = errors.join("<br>");
  } else {
    errorMsgs.innerHTML = "";
  }
  var result = (errors.length === 0);
  return result;
}

function validateName(name) {
  if (name.length < 3) return "Name should be at least 3 characters.";
  return "";
}

function validateEmail(email) {
  if (!email.includes("@")) return "Email should contain '@'.";
  return "";
}

function validateMessage(message) {
  if (message.length < 6) return "Message should be at least 6 characters.";
  return "";
}

