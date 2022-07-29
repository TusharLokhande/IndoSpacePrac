using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndoSpacePrac.Service.Employee;
using IndoSpacePrac.Core.Entity.Employee;
using IndoSpacePrac.Web.MVC.Controllers;
using IndoSpacePrac.Web.Extension;
using IndoSpacePrac.Web.Models.Employee;
using IndoSpacePrac.Web.Models.DropDown;
using AutoMapper;
using IndoSpacePrac.Service.DropDown;

namespace IndoSpacePrac.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        #region Fields
       
        private readonly IEmployeeService  _EmployeeService;
        #endregion
        private readonly IDropDown _DropDownService;
        #region Constructor
        
        public EmployeeController(IEmployeeService employeeService, IDropDown DropDownService)
        {
           this._EmployeeService= employeeService;
            this._DropDownService= DropDownService;
        }
        #endregion

        public ActionResult Index()
        {
            EmployeeModel obj = new EmployeeModel();
            return View(obj);
        } 
        
        public ActionResult Create(int? id)
        {
            EmployeeModel obj = new EmployeeModel();

            // var Department = Mapper.Map<IEnumerable<DropDownModel>>(_DropDownService.GetDeparmentList().Select(x => x)).ToList();
            //var departmentList = Department.ToList();

            if(id > 0)
            {
                var data = Mapper.Map<EmployeeModel>(_EmployeeService.GetEmployeeById(id));
                obj = data;
            }

            var a = _DropDownService.GetDeparmentList().Select(m => m).ToList();
            var reportingManagerlist = _DropDownService.GetReportingManagerList().Select(m => m).ToList(); 
            
            var departmentlist = a.Select(i => new SelectListItem { Text = i.Name, Value = i.Id.ToString() });
            var reportingManager = reportingManagerlist.Select(m => new SelectListItem { Text = m.Name, Value = m.Id.ToString() });

            obj.Departmentlist = departmentlist.ToList();
            obj.ReportingManagerList = reportingManager.ToList();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            var data = Mapper.Map<EmployeeModel, EmployeeEntity>(model);
            _EmployeeService.InsertAndUpdate(data);
            return RedirectToAction("Index");
        }

        public ActionResult GetEmployeeMaster()
        {
            var op = Mapper.Map<IEnumerable<EmployeeModel>>(_EmployeeService.GetEmployees(10, 1, "EName", "ASC", ""));
            return Json(op, JsonRequestBehavior.AllowGet);   
        }

        public ActionResult GetDepartmentList()
        {
            var list = _DropDownService.GetDeparmentList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        
    }
}