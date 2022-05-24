using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using RAM___RUC_Allocation_Manager.Models.DbConnections;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Leader : User
    {

        #region Enumeration
        public enum SortingOptions
        {
            NameASC,
            NameDESC
        }
        #endregion

        #region Properties
        public virtual ICollection<LeaderProgramme> LeaderProgrammes { get; set; } = new List<LeaderProgramme>();

        [Required]public bool IsAdmin { get; set; }
        //This is test list. Remove once DB is running.
        [NotMapped]
        public List<Programme> Programmes { get; set; }
        /// <summary>
        /// Returns a list of all the Users from the Users in Programme' list of Users.
        /// </summary>
        [NotMapped]
        public List<Employee> ProgrammeUsers
        {
            get
            {
            
                List<Employee> users = new List<Employee>();         

                if (LeaderProgrammes != null)
                {
                    var result = LeaderProgrammes.Select(lp => lp.Programme);
                    foreach (Programme p in result)
                    {
                        users.AddRange(p.EmployeeProgrammes.Select(ep => ep.Employee));

                    }
                }

                return users;

            }
        }
        //This is test list. Remove once DB is running.
        //[NotMapped]
        //public List<Programme> Programmes { get; set; }
        // /// <summary>
        ///// Returns a list of all the Users from the Users in Programme' list of Users.
        ///// </summary>
        // [NotMapped]
        // public List<Employee> ProgrammeUsers { get
        //    {

        //        List<Employee> users = new List<Employee>();
                
        //        if(Programmes != null)
        //        {

        //            foreach (Programme p in Programmes)
        //            {
        //                users.AddRange(p.Users.Cast<Employee>());
        //            }

        //        }

        //        return users;

        //    }
        //}
        #endregion

        #region Constructors
        public Leader()
        {
            Type = UserType.Leader;
            Email = "RAM-Leader-Test@Tier1TCG.dk";
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that returns a ClaimsPrincipal to be used for authentication. Since this object is a leader, it's also plausible for the leader to be an "adminstrator".
        /// </summary>
        /// <returns>Claims Principal object.</returns>
        public override ClaimsPrincipal GetClaimsPrinciple()
        {

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Name, Username),
                new Claim(ClaimTypes.GivenName, Name),
                //new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Role, Type.ToString())
            };

            //Become adminstrator.
            if (true) claims.Add(new Claim(ClaimTypes.Role, UserType.Adminstrator.ToString()));

            return new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

        }

        /// <summary>
        /// Method that checks if the Leader has the employee in one of it's Programmes.
        /// </summary>
        /// <param name="id">Employee id to check for.</param>
        /// <returns>Returns true, if the Leader has the Employee in one of it's courses, and false if not.</returns>
        public bool HasEmployeeInProgrammeById(int id)
        {

            foreach(User u in ProgrammeUsers)
            {

                if(u.Id == id)
                {
                    Console.WriteLine(u);
                    return true;
                }
            }

            return false;

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
