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
    public class EmployeeMasterValidator : BaseValidator<EmployeeModel>
    {
        #region Fields 
        
            private readonly IEmployeeService _EmployeeService;

        #endregion

        #region Constructor
                
            public EmployeeMasterValidator(IEmployeeService employeeService)
            {
                this._EmployeeService = employeeService;
                RuleFor(x => x.EName).NotNull().WithMessage("Employee Name is Required");
                RuleFor(x => x.Email).NotNull().WithMessage("Employee Email is Required").Must(CheckEmail).WithMessage("Email is not Valid!");
                
            }


        #endregion

        #region Methods

        public bool CheckEmail(EmployeeModel model, string EmailId)
        {
            if (!String.IsNullOrEmpty(model.Email))
            {
                string emailRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex re = new Regex(emailRegex);

                if (re.IsMatch(model.Email) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }


        #endregion
    }
}