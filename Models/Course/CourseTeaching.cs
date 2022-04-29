using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class CourseTeaching : Course
    {

        #region Properties
        public List<Lesson> Lesson { get; set; }
        public int PreparationHoursLength 
        {
            get 
            {
                if (CourseType)
                    return UAHoursLength;
                else
                    return SULHoursLength;
            }
        }
        public static int UAHoursLength { get; set; }
        public static int SULHoursLength { get; set; }
        #endregion

        #region Constructors
        public CourseTeaching() { }
        public CourseTeaching(string name, bool type) : base(name, type) { }
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
