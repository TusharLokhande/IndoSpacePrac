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
            Int64 totalCount = 0;
                var data = _EmployeeService.tp().Select(x => x.ToModel()).ToList();
                    
           // var data = _EmployeeService.GetEmployees(10, 1,"EName", "ASC","").Select(x => x.ToModel()).ToList();
                Int64 recordsTotal = 0;
                if(data.Count() > 0)
                {
                    totalCount = data[0].TotalCount;
                }
                else
                {
                    totalCount = 0;
                }
                recordsTotal = totalCount;
                return Json(new { data = data, recordsTotal = recordsTotal }, JsonRequestBehavior.AllowGet);
            
            
        }

    }
}