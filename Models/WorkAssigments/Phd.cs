using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public class Phd
    {

        #region Properties
        public int ID { get; set; }
        public Employee MainSupervisor { get; set; }
        public Employee SecondarySupervisor { get; set; }
        public Employee EndEvaluator { get; set; }
        #endregion

    }
}
