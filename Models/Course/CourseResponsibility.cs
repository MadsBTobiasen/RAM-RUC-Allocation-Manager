using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class CourseResponsibility : Course
    {

        #region Properties
        public int HoursLength
        {
            get
            {
                if (CourseType)
                {

                    return SABHoursLength;
                }
                else
                    return SIBHoursLength;
            }
        }
        public Proffessor ProfessorResponsible { get; set; }
        public static int SABHoursLength { get; set; }
        public static int SIBHoursLength { get; set; }
        #endregion

        #region Constructors
        public CourseResponsibility() { }

        public CourseResponsibility(string name, bool type) : base(name, type) { }
        #endregion

        #region Methods

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override string ToString()
        {
            return base.ToString();
        }

        #endregion

    }
}
