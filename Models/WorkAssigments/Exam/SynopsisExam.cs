using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments.Exam
{
    public class SynopsisExam : Exam
    {

        #region Properties
        public static int SynopsisExamMinuteLength { get; set; }
        #endregion

        #region Methods
        public override int CalculateMinutes(User user)
        {
            return 0;
        }
        #endregion

    }
}
