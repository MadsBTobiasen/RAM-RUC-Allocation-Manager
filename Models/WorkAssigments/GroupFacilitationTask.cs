using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public class GroupFacilitationTask
    {

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FacilitatorId { get; set; }
        public Employee Facilitator { get; set; }
        public int DaysSpan { get; set; }
        #endregion

    }

}
