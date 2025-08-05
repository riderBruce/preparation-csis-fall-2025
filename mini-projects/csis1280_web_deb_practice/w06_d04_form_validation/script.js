const form = document.getElementById("registration");
const errorDiv = document.getElementById("errorDiv");
const toastMsg = document.getElementById("toastMsg");

const inputs = form.querySelectorAll("input");

form.addEventListener("input", () => {
  validateInputs();
});

document.getElementById("name").addEventListener("blur", validateInputs);
document.getElementById("email").addEventListener("blur", validateInputs);
document.getElementById("password").addEventListener("blur", validateInputs);

form.addEventListener("submit", (e) => {
  e.preventDefault();
  if (validateInputs()) {
    toastMsg.textContent = "✅ Successfully added!";
    errorDiv.innerHTML = "";
    form.reset();
    inputs.forEach((input) => input.classList.remove("valid", "invalid"));
    setTimeout(() => {
      toastMsg.textContent = "";
    }, 3000);
  }
});

function setValid(input) {
  input.classList.add("valid");
  input.classList.remove("invalid");
}

function setInvalid(input) {
  input.classList.add("invalid");
  input.classList.remove("valid");
}

function validateName(name) {
  if (name.trim().length < 3) {
    setInvalid(form.name);
    return "Name must be at least 3 characters.";
  }
  setValid(form.name);
  return "";
}

function validateEmail(email) {
  const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!emailPattern.test(email)) {
    setInvalid(form.email);
    return "Email must include '@'.";
  }
  setvalid(form.email);
  return "";
}

function validatePassword(password) {
  if (password.trim().length < 6) {
    setInvalid(form.password);
    return "Password must be at least 6 characters.";
  }
  setValid(form.password);
  return "";
}

function validateInputs() {
  const name = form.name.value.trim();
  const email = form.email.value.trim();
  const password = form.password.value;

  const errors = [
    validateName(name),
    validateEmail(email),
    validatePassword(password),
  ].filter((msg) => msg);
  errorDiv.innerHTML = errors.join("<br>");
  return errors.length === 0;
}
