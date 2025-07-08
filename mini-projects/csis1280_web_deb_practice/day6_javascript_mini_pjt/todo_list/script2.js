const taskInput = document.getElementById("taskInput");
const addTaskBtn = document.getElementById("addTaskBtn");
const taskList = document.getElementById("taskList");

addTaskBtn.addEventListener("click", addTask);
taskInput.addEventListener("keypress", e => {
    if (e.key === "enter") addTask();
});

function addTask() {
    // Get text -> Create li -> Add text in li
    const taskText = taskInput.value.trim();
    if (taskText === "") return;
    const li = document.createElement("li");
    li.textContent = taskText;
    // Event completed with CSS
    li.addEventListener("click", () => {
        li.classList.toggle("completed");
    });
    // Create btn -> Add text, class name, Event -> Add btn in li -> Add li in list
    const removeBtn = document.createElement("button");
    removeBtn.textContent = "x";
    removeBtn.className = "remove-btn";
    removeBtn.addEventListener("click", e => {
        e.stopPropagation();
        taskList.removeChild(li);
    });
    li.appendChild(removeBtn);
    taskList.appendChild(li);
    // clear input
    taskInput.value = "";
}