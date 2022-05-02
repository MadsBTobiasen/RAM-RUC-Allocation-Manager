using RAM___RUC_Allocation_Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments.Misc
{
    public class Misc : IWorkAssignment
    {

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// TODO:
        /// 
        /// Udfyld MISC-typen, heraf de forskellige statiske ints, samt udregning deraf.
        /// 
        /// </summary>
        #endregion

        #region Methods
        public int CalculateMinutes(User user)
        {
            return 0;
        }
        #endregion
    
    }
}
