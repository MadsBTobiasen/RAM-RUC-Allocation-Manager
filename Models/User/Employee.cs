using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public EmployeeTitle Title { get; set; }
        public bool IsGroupLeader { get; set; }
        public List<EmployeeCourse> Courses { get; set; }
        public List<Programme> Programmes { get; set; }
        public List<Redemption> Redemption { get; set; }
        #endregion

        #region Constructors

        #endregion

        #region Methods
        public int CalculateTotalAllocationMinutes()
        {
            return 0;
        }

        public int CalculateTotalCourseMinutes()
        {
            return 0;
        }

        public int CalculateTotalSupervisionMinutes()
        {
            return 0;
        }

        public int CalculateTotalExamMinutes()
        {
            return 0;
        }

        public int CalculateTotalMiscMinutes()
        {
            return 0;
        }

        public int CalculateSavings()
        {
            return 0;
        }

        public int CalculateMinuteBalance()
        {
            return 0;
        }

        public int CalculateRedeemedMinutes()
        {
            return 0;
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
            return $"[Employee] ({ID}) {Name} {Password} {Email}";
        }


        #endregion

    }
}