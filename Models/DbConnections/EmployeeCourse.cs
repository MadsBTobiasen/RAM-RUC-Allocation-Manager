using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public class EmployeeCourse
    {

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        [Required]
        public int RelativeLectureAmount { get; set; }
        #endregion

    }
}
