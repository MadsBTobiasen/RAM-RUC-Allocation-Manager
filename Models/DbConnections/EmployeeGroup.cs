using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.DbConnections
{
    public class EmployeeGroup
    {
        public enum EmployeeRole
        {
            InternalCensor,
            Supervisor
        }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public EmployeeRole RoleOfEmployee { get; set; }

    }
}
