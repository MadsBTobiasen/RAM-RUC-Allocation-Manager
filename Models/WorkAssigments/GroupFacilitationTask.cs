using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public class GroupFacilitationTask
    {

        #region Properties
        public int ID { get; set; }
        public Employee Facilitator { get; set; }
        public int DaysSpan { get; set; }
        #endregion

    }

}
