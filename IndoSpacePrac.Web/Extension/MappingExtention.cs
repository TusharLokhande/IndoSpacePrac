using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndoSpacePrac.Core.Entity.Employee;
using IndoSpacePrac.Core.Entity.Common;
using IndoSpacePrac.Web.Models.Employee;
using IndoSpacePrac.Web.Models.DropDown;

namespace IndoSpacePrac.Web.Extension
{
    public static class MappingExtention
    {

        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }


        #region Employee


        public static EmployeeModel ToModel(this EmployeeEntity emp)
        {
            return emp.MapTo<EmployeeEntity, EmployeeModel>();
        }

        public static EmployeeEntity ToEntity(this EmployeeModel model)
        {
            return model.MapTo<EmployeeModel, EmployeeEntity>();
        }
        
        public static EmployeeEntity ToEntity(this EmployeeModel model, EmployeeEntity destination)
        {
            return model.MapTo(destination);
        }

        #endregion

        #region Department 
            
        #endregion
    }
}