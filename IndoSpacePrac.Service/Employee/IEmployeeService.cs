﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndoSpacePrac.Service.Employee;
using IndoSpacePrac.Core.Entity.Employee;

namespace IndoSpacePrac.Service.Employee
{
    public interface IEmployeeService
    {
         IEnumerable<EmployeeEntity> GetEmployees(int pageSize, int start, string sortColumn, string sortOrder, string searchText);
    }

}
