const button = document.getElementById("colorBtn");

button.addEventListener("click", () => {
    const randomColor = getRandomColor();
    document.body.style.backgroundColor = randomColor;
});

function getRandomColor() {
  const letters = "0123456789ABCDEF";
  let color = "#";
  for (let i = 0; i < 6; i++) {
    color += letters[getRandomInt(16)];
  }
  return color;
}

function getRandomInt(max) {
  return Math.floor(Math.random() * max);
}