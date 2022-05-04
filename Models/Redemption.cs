using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Redemption
    {

        #region Properties
        public Employee Employee { get; set; }
        public Semester Semester { get; set; }
        public int MinutesRedeemedForSemester { get; set; }
        #endregion

    }
}
