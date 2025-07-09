async function getWeather() {
  const city = document.getElementById("cityInput").value;
  const apiKey = "YOUR_API_KEY";
  const url = `https://api.openweathermap.org/data/2.5/weather?q=${city}&units=metric&appid=${apiKey}`;

  const weatherResult = document.getElementById("weatherResult");

  try {
    const response = await fetch(url);
    if (!response.ok) throw new Error("City not found");
    const data = await response.json();

    const { name, main, weather } = data;
    weatherResult.innerHTML = `
      <h2>${name}</h2>
      <p>🌡️ Temp: ${main.temp}°C</p>
      <p>💧 Humidity: ${main.humidity}%</p>
      <p>🌤️ Condition: ${weather[0].description}</p>
    `;
  } catch (error) {
    weatherResult.innerHTML = `<p style="color:red;">${error.message}</p>`;
  }
}