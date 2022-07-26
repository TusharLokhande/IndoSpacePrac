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


namespace IndoSpacePrac.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        #region Fields
       
        private readonly IEmployeeService  _EmployeeService;
        #endregion

        #region Constructor

        public EmployeeController()
        {
           // _EmployeeService = new EmployeeService();
        }

        public EmployeeController(IEmployeeService employeeService)
        {
           this._EmployeeService= employeeService;
        }
        #endregion

        public ActionResult Index()
        {
           // List<EmployeeModel> list = new List<EmployeeModel>();
            EmployeeModel emp = new EmployeeModel();
            emp.EmployeeList = _EmployeeService.GetEmployees(10, 1, "EName", "ASC", "").ToList();
            //list.Add(emp);     
            return View(emp);
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
    }
}