using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Group
    {

        #region Properties
        public int ID { get; set; }
        public int RUCID { get; set; }
        public bool IsMasterThesis { get; set; }
        public Employee Supervisor { get; set; }
        public Employee InternalCensor { get; set; }
        #endregion

        #region Methods

        #endregion

    }
}
