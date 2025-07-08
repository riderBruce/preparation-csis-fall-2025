const display = document.getElementById("display");

function appendValue(value) {
  display.value += value;
}

function clearDisplay() {
  display.value = "";
}

function calculate() {
  try {
    display.value = eval(display.value);
  } 
  catch (error) {
    alert("Invalid expression");
  }
}

// function appendValue(value) {
//   const display = document.getElementById("display");
//   display.value += value;
// }

// function clearDisplay() {
//   document.getElementById("display").value = "";
// }

// function calculate() {
//   try {
//     const result = eval(document.getElementById("display").value);
//     document.getElementById("display").value = result;
//   } catch (error) {
//     alert("Invalid expression");
//   }
// }