﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Redemption
    {

        #region Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public Semester Semester { get; set; }
        public int MinutesRedeemedForSemester { get; set; }
        #endregion

    }
}