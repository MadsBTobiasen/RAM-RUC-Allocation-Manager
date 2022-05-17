using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee;

namespace RAM___RUC_Allocation_Manager.Models.DbConnections
{
    public class EmployeeCustomCommittee
    {
        public int EmpployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CustomCommitteeId { get; set; }
        public CustomCommittee CustomCommittee { get; set; }
    }
}
