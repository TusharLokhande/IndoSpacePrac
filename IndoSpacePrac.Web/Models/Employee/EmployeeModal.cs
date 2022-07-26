using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndoSpacePrac.Core.Entity.Employee;


namespace IndoSpacePrac.Web.Models.Employee
{
    public class EmployeeModel :BaseModel
    {
        public List<EmployeeEntity> EmployeeList { get; set; }


        public new long Id { get; set; }
        public new long TotalCount { get; set; }

        public string EName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }

        public string ReportingManagerName { get; set; }

        public int ReportingManagerId { get; set; }

        public string Email { get; set; }

        public int isActive { get; set; }

        
    }
}