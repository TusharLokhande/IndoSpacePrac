let Obj = {}

console.log("LL");

function op (id) { return `<a href="/Employee/Create/${id}">Edit</a>` }

$(document).ready(() => {

    $.noConflict();
    let c = `<a href="/Employee/Create/Id">Edit</a>`;
    $.ajax({
        'url': "/Employee/GetEmployeemaster",
        'method': "GET",
        'contentType': 'application/json'
    }).done(function (data) {
        $('#table').dataTable({

            "data": data,
            "columns": [
                { "data": "EName" },
                { "data": "Email" },
                { "data": "DepartmentName" },
                { "data": "ReportingManagerName" },
                { "render": function (data, type, full, meta) { return `<a href="/Employee/Create/${full.Id}">Edit</a>` } }
            ],
        });



    })
})
