using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee
{
    public class CustomCommittee
    {

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public int MinuteWorth { get; set; }
        public List<Employee> Employees { get; set; }
        #endregion

    }
}
