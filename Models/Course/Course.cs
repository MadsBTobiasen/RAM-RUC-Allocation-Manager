using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public abstract class Course
    {

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public bool CourseType { get; set; }
        #endregion

        #region Constructor
        protected Course() { }

        protected Course(string name, bool type)
        {
            Name = name;
            CourseType = type;
        }
        #endregion

    }
}
