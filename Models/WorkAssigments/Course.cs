using System;
using System.Collections.Generic;
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
        public Employee ResponsibleEmployee { get; set; }
        public int LectureAmount { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
        public CourseType Type { get; set; }
        #endregion

    }
}
