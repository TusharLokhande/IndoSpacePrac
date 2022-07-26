using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IndoSpacePrac.Web.Models.Employee;
using IndoSpacePrac.Core.Infrastructure;
using IndoSpacePrac.Core.Entity.Employee;

namespace IndoSpacePrac.Web.Infrastructure
{
    public class AutoMapperStartupTask : IStartupTask
    {
        public int Order
        {
            get { return 1; }
        }
        

        public void Execute()
        {
            #region Employee
            Mapper.CreateMap<EmployeeModel,EmployeeEntity>();
            Mapper.CreateMap<EmployeeEntity, EmployeeModel>();
            #endregion
        }

    }
}