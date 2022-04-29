using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class GroupFormationFacilitation
    {

        #region Fields
        private int _daysLength = 1;
        #endregion

        #region Properties
        public string ID { get; set; }
        public string Name { get; set; }
        public int HoursLength 
        { 
            get
            {
                return (DaysLength - 1) * DayHoursValue + InitialHoursValue + ExtraHoursLength;
            } 
        }
        public int DaysLength
        {
            get { return _daysLength; }
            set
            {
                if (value == 1 || value == 2 || value == 3) _daysLength = value;
                else
                {
                    throw new Exception("Amount of days outside of range (1-3)");
                }
            }
        }
        public int ExtraHoursLength { get; set; }

        public static int DayHoursValue { get; set; }
        public static int InitialHoursValue { get; set; }
        #endregion

        #region Constructors
        public GroupFormationFacilitation() { }
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
