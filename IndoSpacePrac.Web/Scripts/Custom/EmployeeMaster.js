let Obj = {}

console.log("LL");

$(document).ready(() => {

    $.noConflict();

    $.ajax({
        'url': "/Employee/GetEmployeemaster",
        'method': "GET",
        'contentType': 'application/json'
    }).done(function (data) {
        $('#table').dataTable({
            "aaData": data,
        "columns": [
            { "data": "EName" },
            { "data": "Email" },
            { "data": "DepartmentName" },
            { "data": "ReportingManagerName" }
        ]
        })
    })
})
