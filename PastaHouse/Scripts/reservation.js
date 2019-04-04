window.onload = function () {
    var today = new Date();
    today = transformDate(today, 1);

    var maxDate = new Date();
    maxDate = transformDate(maxDate, 14);

    var tomorrow = new Date();
    tomorrow.setDate(tomorrow.getDate() + 1);

    document.getElementById('datePicker').valueAsDate = tomorrow;
    document.getElementById('datePicker').setAttribute("min", today);
    document.getElementById('datePicker').setAttribute("max", maxDate);
};

function transformDate(date, days) {
    date.setDate(date.getDate() + days)
    var dd = date.getDate();
    var mm = date.getMonth() + 1;
    var yyyy = date.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    return yyyy + '-' + mm + '-' + dd;
}