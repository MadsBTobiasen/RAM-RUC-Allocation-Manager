using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public abstract class User
    {

        #region Enumerations
        public enum UserTypes {
            Admin = 0,
            Leader = 1,
            Professor = 2
        }
        #endregion

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserTypes UserType { get; set; }
        #endregion

        #region Constructors

        #endregion

        #region Methods

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
