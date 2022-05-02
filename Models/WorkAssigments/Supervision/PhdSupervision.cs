﻿using RAM___RUC_Allocation_Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public class PhdSupervision : Supervision
    {

        #region Properties
        public bool IsMainSupervisor { get; set; }
        public static int MainSupervisorMinuteLength { get; set; }
        public static int SecondarySupervisorMinutesLength { get; set; }
        #endregion

        #region Methods
        public override int CalculateMinutes(User user)
        {
            return 0;
        }
        #endregion
    }
}
