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

namespace IndoSpacePrac.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        #region Fields
       
        private readonly IEmployeeService  _EmployeeService;
        #endregion

        #region Constructor
        
        public EmployeeController(IEmployeeService employeeService)
        {
           this._EmployeeService= employeeService;
        }
        #endregion

        public ActionResult Index()
        {
            EmployeeModel obj = new EmployeeModel();
            return View(obj);
        } 
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeEntity entity)
        {

            try
            {
                _EmployeeService.InsertAndUpdate(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index","Employee");
        }

        public ActionResult ge()
        {

            var op = Mapper.Map<IEnumerable<EmployeeModel>>(_EmployeeService.tp());

            var data = _EmployeeService.GetEmployees(10, 1, "EName", "ASC", "");
            return Json(op, JsonRequestBehavior.AllowGet);
            
            
        }

    }
}