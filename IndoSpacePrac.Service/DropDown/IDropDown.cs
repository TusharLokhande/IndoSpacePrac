using IndoSpacePrac.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoSpacePrac.Service.DropDown
{
    public interface IDropDown
    {
        IEnumerable<DropDownEntity> GetDeparmentList();

        IEnumerable<DropDownEntity> GetReportingManagerList();
    }
}
