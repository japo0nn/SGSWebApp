function workshopUpdate() {
    var citySelect = document.getElementById("city");
    var workshopSelect = document.getElementById("workshop");

    switch (citySelect.value) {
        case "Astana":
            workshopSelect.innerHTML = "";
            workshopSelect.options.add(new Option("Выберите цех", ""));
            workshopSelect.options.add(new Option("Астана цех 1", "Астана цех 1"));
            workshopSelect.options.add(new Option("Астана цех 2", "Астана цех 2"));
            break;
        case "Almaty":
            workshopSelect.innerHTML = "";
            workshopSelect.options.add(new Option("Выберите цех", ""));
            workshopSelect.options.add(new Option("Алматы цех 1", "Алматы цех 1"));
            workshopSelect.options.add(new Option("Алматы цех 2", "Алматы цех 2"));
            break;
        case "Shymkent":
            workshopSelect.innerHTML = "";
            workshopSelect.options.add(new Option("Выберите цех", ""));
            workshopSelect.options.add(new Option("Шымкент цех 1", "Шымкент цех 1"));
            workshopSelect.options.add(new Option("Шымкент цех 2", "ШЫмкент цех 2"));
            break;
        case "Taraz":
            workshopSelect.innerHTML = "";
            workshopSelect.options.add(new Option("Выберите цех", ""));
            workshopSelect.options.add(new Option("Тараз цех", "Тараз цех"));
            break;
        case "Qyzylorda":
            workshopSelect.innerHTML = "";
            workshopSelect.options.add(new Option("Выберите цех", ""));
            workshopSelect.options.add(new Option("Кызылорда цех", "Кызылорда цех"));
            break;
        default:
            workshopSelect.innerHTML = "";
            workshopSelect.options.add(new Option("Выберите цех", ""));
            workshopSelect.options.add(new Option("Астана цех 1", "Астана цех 1"));
            workshopSelect.options.add(new Option("Астана цех 2", "Астана цех 2"));
            workshopSelect.options.add(new Option("Алматы цех 1", "Алматы цех 1"));
            workshopSelect.options.add(new Option("Алматы цех 2", "Алматы цех 2"));
            workshopSelect.options.add(new Option("Шымкент цех 1", "Шымкент цех 1"));
            workshopSelect.options.add(new Option("Шымкент цех 2", "Шымкент цех 2"));
            workshopSelect.options.add(new Option("Тараз цех", "Тараз цех"));
            workshopSelect.options.add(new Option("Кызылорда цех", "Кызылорда цех"));
            break;
    }
    document.getElementById("employee").innerHTML = "<option value=''>Выберите сотрудника</option>";
}

// Функция для обновления списка сотрудников в зависимости от выбранного цеха
function employeeUpdate() {
    var workshopSelect = document.getElementById("workshop");
    var employeeSelect = document.getElementById("employee");

    // Очищаем список сотрудников
    employeeSelect.innerHTML = "";

    // Добавляем опции в зависимости от выбранного цеха
    switch (workshopSelect.value) {
        case "Астана цех 1":
            employeeSelect.innerHTML = "";
            employeeSelect.options.add(new Option("Выберите сотрудника", ""));
            employeeSelect.options.add(new Option("Астана сотрудник 1", "Астана сотрудник 1"));
            break;
        case "Астана цех 2":
            employeeSelect.innerHTML = "";
            employeeSelect.options.add(new Option("Выберите сотрудника", ""));
            employeeSelect.options.add(new Option("Астана сотрудник 2", "Астана сотрудник 2"));
            break;
        case "Алматы цех 1":
            employeeSelect.innerHTML = "";
            employeeSelect.options.add(new Option("Выберите сотрудника", ""));
            employeeSelect.options.add(new Option("Алматы сотрудник 1", "Алматы сотрудник 1"));
            break;
        case "Алматы цех 2":
            employeeSelect.innerHTML = "";
            employeeSelect.options.add(new Option("Выберите сотрудника", ""));
            employeeSelect.options.add(new Option("Алматы сотрудник 2", "Алматы сотрудник 2"));
            break;
        case "Шымкент цех 1":
            employeeSelect.innerHTML = "";
            employeeSelect.options.add(new Option("Выберите сотрудника", ""));
            employeeSelect.options.add(new Option("Шымкент сотрудник 1", "Шымкент сотрудник 1"));
            break;
            case "Шымкент цех 2":
            employeeSelect.innerHTML = "";
            employeeSelect.options.add(new Option("Выберите сотрудника", ""));
            employeeSelect.options.add(new Option("Шымкент сотрудник 2", "Шымкент сотрудник 2"));
            break;
        case "Тараз цех":
            employeeSelect.innerHTML = "";
            employeeSelect.options.add(new Option("Выберите сотрудника", ""));
            employeeSelect.options.add(new Option("Тазар сотрудник", "Тараз сотрудник"));
            break;
        case "Кызылорда цех":
            employeeSelect.innerHTML = "";
            employeeSelect.options.add(new Option("Выберите сотрудника", ""));
            employeeSelect.options.add(new Option("Кызылорда сотрудник", "Кызылорда сотрудник"));
            break;
        default:
            employeeSelect.innerHTML = "";
            employeeSelect.options.add(new Option("Выберите сотрудника", ""));
            employeeSelect.options.add(new Option("Астана сотрудник 1", "Астана сотрудник 1"));
            employeeSelect.options.add(new Option("Астана сотрудник 2", "Астана сотрудник 2"));
            employeeSelect.options.add(new Option("Алматы сотрудник 1", "Алматы сотрудник 1"));
            employeeSelect.options.add(new Option("Алматы сотрудник 2", "Алматы сотрудник 2"));
            employeeSelect.options.add(new Option("Шымкент сотрудник 1", "Шымкент сотрудник 1"));
            employeeSelect.options.add(new Option("Шымкент сотрудник 2", "Шымкент сотрудник 2"));
            employeeSelect.options.add(new Option("Тараз сотрудник", "Тараз сотрудник"));
            employeeSelect.options.add(new Option("Кызылорда сотрудник", "Кызылорда сотрудник"));
            break;
    }
}

function saveData() {
    var formData = {
        city: document.getElementById("city").value,
        workshop: document.getElementById("workshop").value,
        employee: document.getElementById("employee").value,
        brigade: document.getElementById("brigade").value,
        shift: document.getElementById("shift").value
    };

    var jsonData = JSON.stringify(formData);

    document.cookie = "jsonData=" + jsonData + "; path=/home";

    alert("Saved!");
}
