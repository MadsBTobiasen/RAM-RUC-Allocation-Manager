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
    public class User
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
        /// OPMÆRKSOMHED HER
        /// OPMÆRKSOMHED HER
        /// PASSWORD'S SET ER SAT TIL PRIVATE. DA NÅR ET KODEORD SKAL ÆNDRES ELLER OPRETTES SKAL DET HASHES / SÆTTES GENNEM
        /// SETPASSWORD() METODEN. SET-ACCESSOREN SKAL VÆRE PUBLIC NÅR DATABASE KØRER.
        /// OPMÆRKSOMHED HER
        /// OPMÆRKSOMHED HER
        /// </summary>
        [Required]
        public string Password { get; private set; }

        /*
        *
        *
        *
        */

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
