using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;

namespace RAM___RUC_Allocation_Manager.Models.DbConnections
{
    public class PhdTasks
    {
        public enum EmployeeRole
        {
            MainSupervisor,
            SecondarySupervisor,
            EndEvaluator
        }

        public int Id { get; set; }
        public Employee Employee { get; set; }
        public EmployeeRole RoleOfEmployee { get; set; }
    }
}
