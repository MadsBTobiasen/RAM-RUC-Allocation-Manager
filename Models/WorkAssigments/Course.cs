using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public class Course
    {

        #region Enumerations
        public enum CourseType
        {
            SAB,
            SIB,
            Standard
        }
        #endregion

        #region Properties
        public int? EmployeeId { get; set; }
        public Employee ResponsibleEmployee { get; set; }
        [Required]
        public int LectureAmount { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public CourseType Type { get; set; }
        #endregion

    }
}
