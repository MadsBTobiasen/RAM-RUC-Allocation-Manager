using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public class AssistantProfessorSupervision
    {

        #region Properties
        public int ID { get; set; }
        public Employee Supervisor { get; set; }
        public Employee AssistantProfessor { get; set; }
        #endregion

    }
}
