using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Leader : User
    {

        #region Properties

        #endregion

        #region Constructors

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
