using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.WorkAssigments
{
    public class Phd
    {

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Employee MainSupervisor { get; set; }
        public Employee SecondarySupervisor { get; set; }
        public Employee EndEvaluator { get; set; }
        #endregion

    }
}
