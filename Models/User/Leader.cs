using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models.DbConnections;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Leader : User
    {

        #region Properties
        public virtual ICollection<LeaderProgramme> LeaderProgrammes { get; set; }
        #endregion

        #region Constructors

        public Leader()
        {
            Type = UserType.Leader;
        }

        #endregion

        #region Methods
        public override ClaimsPrincipal GetClaimsPrinciple()
        {
            return null;
        }

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
