using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models.DbConnections;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee
{
    public class HiringCommittee
    {

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int PeopleToBeAssessed { get; set; }
        public virtual ICollection<EmployeeHiringCommittee> EmployeeHiringCommittees { get; set; } = new List<EmployeeHiringCommittee>();
        #endregion

    }
}
