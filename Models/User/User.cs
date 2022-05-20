using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public abstract class User
    {

        #region Enumerations
        public enum UserType
        {
            Employee,
            Leader,
            Adminstrator
        }
        #endregion

        #region Fields
        private static PasswordHasher<string> hasher = new PasswordHasher<string>();
        #endregion

        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(35)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        /// <summary>
        /// If you wish to set a new password, be it through the update form, or when adding a new user.
        /// Use the SetPassword() Method. 
        /// </summary>
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        [NotMapped]
        public UserType Type { get; set; }
        #endregion

        #region Constructors

        #endregion

        #region Methods
        /// <summary>
        /// Overridable function.
        /// Throws an error as it HAS to be overriden by it's children.
        /// </summary>
        public virtual ClaimsPrincipal GetClaimsPrinciple()
        {
            throw new Exception("Method must be overriden.");
        }

        /// <summary>
        /// Method that sets the password. This is needed, so that everytime a password has to be changed,
        /// it can be done so using a passwordHasher.
        /// </summary>
        public void SetPassword(string password)
        {
            Password = hasher.HashPassword(null, password);
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
            return $"User: ({Id}) {Name} {Username} {Email}";
        }
        #endregion

    }
}
