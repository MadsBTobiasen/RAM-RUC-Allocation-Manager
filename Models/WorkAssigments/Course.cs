using RAM___RUC_Allocation_Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssignments
{
    public class Course : IWorkAssignment
    {

        #region Enumerations
        public enum CourseTypes
        {
            Standard = 0,
            SAB = 1,
            SIB = 2
        }
        #endregion

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public Employee ResponsibleEmployee { get; set; }
        public int LectureAmount { get; set; }
        public CourseTypes CourseType { get; set; }
        public static int LectureMinuteLength { get; set; }
        public static int StandardMinuteLength { get; set; }
        public static int SABMinuteLength { get; set; }
        public static int SIBMinuteLength { get; set; }
        #endregion

        #region Methods
        public int CalculateMinutes(User user)
        {
            return 0;
        }
        #endregion

    }
}
