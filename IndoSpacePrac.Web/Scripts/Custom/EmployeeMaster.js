


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
                { "render": function (data, type, full, meta) { return `<a class="btn btn-primary" href="/Employee/Create/${full.Id}">Update</a> <a class="btn btn-default" href="/Employee/Create/${full.Id}">Delete</a>` } },
            ],
        });



    })
})
