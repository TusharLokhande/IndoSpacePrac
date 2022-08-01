
$.fn.dataTable.render.moment = function (from, to, locale) {
    // Argument shifting
    if (arguments.length === 1) {
        locale = 'en';
        to = from;
        from = 'YYYY-MM-DD';
    }
    else if (arguments.length === 2) {
        locale = 'en';
    }

    return function (d, type, row) {
        if (!d) {
            return type === 'sort' || type === 'type' ? 0 : d;
        }

        var m = window.moment(d, from, locale, true);

        // Order and type get a number value from Moment, everything else
        // sees the rendered value
        return m.format(type === 'sort' || type === 'type' ? 'x' : to);
    };
};

/*
 var str = "/Date(1268524800000)/";
var num = parseInt(str.replace(/[^0-9]/g, ""));
 */

$(document).ready(() => {

    $.noConflict();
    $.ajax({
        'url': "/Employee/GetEmployeemaster",
        'method': "GET",
        'contentType': 'application/json'
    }).done(function (data) {
        console.log(data);
        let date = new Date();
        $('#table').dataTable({

            "data": data,
            "columns": [
                { "data": "EName" },
                { "data": "Email" },
                {
                    "data": (data) => {
                        var str = String(data.DateOfBirth);
                        var num = parseInt(str.replace(/[^0-9]/g, ""));
                        let d = new Date(num).toLocaleDateString("en-US");
                        console.log(d);
                        return d;
                    }
                       
                        
                } ,
                { "data": "DepartmentName" },
                { "data": "ReportingManagerName" },
                { "render": function (data, type, full, meta) { return `<a class="btn btn-primary" href="/Employee/Create/${full.Id}">Update</a> <a class="btn btn-default" href="/Employee/Create/${full.Id}">Delete</a>` } },
            ],
        });



    })
})
