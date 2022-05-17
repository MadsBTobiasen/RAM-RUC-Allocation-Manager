using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models.DbConnections;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee
{
    public class CustomCommittee
    {

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MinuteWorth { get; set; }
        public virtual ICollection<EmployeeCustomCommittee> EmployeesCustomCommittees { get; set; } = new List<EmployeeCustomCommittee>();
        #endregion

    }
}
