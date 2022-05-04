using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee
{
    public class HiringCommittee
    {

        #region Properties
        public int ID { get; set; }
        public int PeopleToBeAssessed { get; set; }
        public List<Employee> Employees { get; set; }
        #endregion

    }
}
