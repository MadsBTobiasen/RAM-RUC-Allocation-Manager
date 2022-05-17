using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.DbConnections
{
    public class LeaderProgramme
    {
        public int ProgrammeId { get; set; }

        public Programme Programme { get; set; }
        public int LeaderId { get; set; }

        public Leader Leader { get; set; }
    }
}
