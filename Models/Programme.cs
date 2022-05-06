using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models.DbConnections;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Programme
    {

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<EmployeeProgramme> EmployeeProgrammes { get; set; }
        public virtual ICollection<LeaderProgramme> LeaderProgrammes { get; set; }

        //This is test list. Remove after db go vroom
        public List<User> Users { get; set; }
        #endregion

    }
}
