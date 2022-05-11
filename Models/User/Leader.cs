using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        //This is test list. Remove once DB is running.
        public List<Programme> Programmes { get; set; }
         /// <summary>
        /// Returns a list of all the Users from the Users in Programme' list of Users.
        /// </summary>
        public List<User> ProgrammeUsers { get
            {

                List<User> users = new List<User>();
                
                foreach(Programme p in Programmes)
                {
                    users.AddRange(p.Users);
                }

                return users;

            }
        }
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

        //Missing from my version but is needed for LoginService... Attempt to recreate but can be deleted in merge - Falke
        public bool HasEmployeeInProgrammeById(Employee user)
        {
            foreach (int userId in user.EmployeeProgrammes.Select(ep => ep.Programme.Id))
            {
                if (LeaderProgrammes.Select(lp => lp.Programme.Id).Contains(userId)) return true;
            }

            return false;
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
            return $"[Leader] ({Id}) {Name} {Password} {Email}";
        }

        #endregion
    }
}
