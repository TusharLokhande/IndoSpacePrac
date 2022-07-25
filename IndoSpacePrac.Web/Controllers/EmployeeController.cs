using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndoSpacePrac.Service.Employee;
using IndoSpacePrac.Core.Entity.Employee;
using IndoSpacePrac.Web.MVC.Controllers;
using IndoSpacePrac.Web.Extension;


namespace IndoSpacePrac.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        // GET: Employee
        #region Fields
        private EmployeeService service;
        private readonly IEmployeeService  _ClientMasterService;
        #endregion

        #region Constructor
        public EmployeeController()
        {
            service = new EmployeeService();
            
        }
        #endregion

        public ActionResult Index()
        {
        
           
                var list = service.GetEmployees(10, 1, "EName", "ASC", "");
                return View(list);
          
            
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
                service.InsertAndUpdate(entity);
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index","Employee");
        }
    }
}