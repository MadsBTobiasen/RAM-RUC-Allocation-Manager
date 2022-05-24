using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee
{
    public class PromotionCommitteeTask
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int PeopleToBeAssessed { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
