using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndoSpacePrac.Web.Models.DropDown;



namespace IndoSpacePrac.Web.Models.Employee
{
    public class EmployeeModel : BaseModel
    {
       

        #region Lists
        public List<SelectListItem> Departmentlist { get; set; }
        public List<SelectListItem> ReportingManagerList { get; set; }
        #endregion

        public EmployeeModel()
        {
            Departmentlist = new List<SelectListItem>();
            ReportingManagerList = new List<SelectListItem>();
        }



        #region Property
        public long Id { get; set; }
        public long TotalCount { get; set; }

        public string EName { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }




        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }

        public string ReportingManagerName { get; set; }

        public int ReportingManagerId { get; set; }

        public string Email { get; set; }

        public int isActive { get; set; }
        #endregion

    }
}