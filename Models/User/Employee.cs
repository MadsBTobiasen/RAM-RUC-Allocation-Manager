using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models.DbConnections;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Employee : User
    {

        #region Enumeration
        public enum EmployeeTitle
        {
            Professor,
            AssociateProfessor,
            AssistantProfessor
        }
        #endregion

        #region Properties
        [Required]
        public EmployeeTitle Title { get; set; }
        [Required]
        public bool IsGroupLeader { get; set; }

        [Required]
        public int Balance { get; set; }
        public virtual ICollection<EmployeeCourse> EmployeeCourses { get; set; }
        public virtual ICollection<EmployeeProgramme> EmployeeProgrammes { get; set; }
        public virtual ICollection<Redemption> Redemption { get; set; }
        public virtual ICollection<EmployeeHiringCommittee> EmployeeHiringCommittees { get; set; }
        public virtual ICollection<EmployeeCustomCommittee> EmployeeCustomCommittees { get; set; }

        #endregion

        #region Constructors
        public Employee()
        {
            Type = UserType.Employee;
        }
        #endregion

        #region Methods
        public int CalculateTotalAllocationMinutes()
        {
            return new Random().Next(0, 20) * 30;
        }

        public int CalculateTotalCourseMinutes()
        {
            return new Random().Next(0, 20) * 30;
        }

        public int CalculateTotalSupervisionMinutes()
        {
            return new Random().Next(0, 20) * 30;
        }

        public int CalculateTotalExamMinutes()
        {
            return new Random().Next(0, 20) * 30;
        }

        public int CalculateTotalMiscMinutes()
        {
            return new Random().Next(0, 20) * 30;
        }

        public int CalculateSavings()
        {
            return new Random().Next(0, 20) * 30;
        }

        public int CalculateMinuteBalance()
        {
            return new Random().Next(0, 20) * 30;
        }

        public int CalculateRedeemedMinutes()
        {
            return new Random().Next(0, 20) * 30;
        }

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
            return $"[Employee] ({Id}) {Name} {Password} {Email}";
        }

        #endregion

    }
}