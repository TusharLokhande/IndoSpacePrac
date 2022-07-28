using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using IndoSpacePrac.Core.Entity.Employee;
using IndoSpacePrac.Web.Models.Employee;

namespace IndoSpacePrac.Web.Infrastructure
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            Mapper.CreateMap<EmployeeModel, EmployeeEntity>();
            Mapper.CreateMap<EmployeeEntity, EmployeeModel>();
        }
    }
}