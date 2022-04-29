using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class CourseMisc : Course
    {

        #region Properties
        public List<Lesson> Lessons { get; set; }
        public int PreperationHoursLength { get; set; }
        #endregion

        #region Constructors
        public CourseMisc() { }
        public CourseMisc(string name, bool type) : base(name, type) { }
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
