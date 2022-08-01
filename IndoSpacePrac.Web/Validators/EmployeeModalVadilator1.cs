using IndoSpacePrac.Service.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FluentValidation;
using FluentValidation.Validators;
using IndoSpacePrac.Service.Employee;
using IndoSpacePrac.FrameWork.Validators;
using IndoSpacePrac.Web.Models.Employee;
using System.Text.RegularExpressions;

namespace IndoSpacePrac.Web.Validators
{
    public class EmployeeModalVadilator1 : BaseValidator<EmployeeModel>
    {
         private readonly IEmployeeService _EmployeeService;

        public EmployeeModalVadilator1(IEmployeeService employeeService)
        {
            _EmployeeService = employeeService;
            RuleFor(x => x.Departmentlist).NotEmpty().WithMessage("Department list");
            RuleFor(x => x.ReportingManagerList).NotEmpty().WithMessage("Department list");
        }
    }
}