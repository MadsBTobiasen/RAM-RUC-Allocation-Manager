using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public class EmployeeCourse
    {

        #region Properties
        public Employee Employee { get; set; }
        public Course Course { get; set; }
        public int RelativeLectureAmount { get; set; }
        #endregion

    }
}
