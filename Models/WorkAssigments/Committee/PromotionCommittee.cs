using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee
{
    public class PromotionCommittee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int PeopleToBeAssessed { get; set; }
        [Required]
        public Employee ParticipatingEmployeeOne { get; set; }
        [Required]
        public Employee ParticipatingEmployeeTwo { get; set; }
    }
}
