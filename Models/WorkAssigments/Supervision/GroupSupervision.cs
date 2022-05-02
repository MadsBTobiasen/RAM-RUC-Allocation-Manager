using RAM___RUC_Allocation_Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public class GroupSupervision : Supervision
    {

        #region Properties
        public List<Group> Groups { get; set; }
        public static int GroupSize1MinuteLength { get; set; }
        public static int GroupSize2MinuteLength { get; set; }
        public static int GroupSize3MinuteLength { get; set; }
        public static int GroupSize4MinuteLength { get; set; }
        public static int GroupSize5MinuteLength { get; set; }
        public static int GroupSize6MinuteLength { get; set; }
        #endregion

        #region Methods
        public override int CalculateMinutes(User user)
        {
            return 0;
        }
        #endregion

    }
}
