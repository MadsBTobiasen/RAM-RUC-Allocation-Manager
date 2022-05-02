using RAM___RUC_Allocation_Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public abstract class Supervision : IWorkAssignment
    {

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        #endregion

        #region Methods
        public abstract int CalculateMinutes(User user);
        #endregion

    }
}
