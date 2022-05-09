using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Group
    {

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int RucId { get; set; }
        public bool IsMasterThesis { get; set; }
        public Employee Supervisor { get; set; }
        public Employee InternalCensor { get; set; }
        public int MemberAmount { get; set; }
        #endregion

        #region Methods

        #endregion

    }
}
