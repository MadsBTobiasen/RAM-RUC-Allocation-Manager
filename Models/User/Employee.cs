using RAM___RUC_Allocation_Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models
{
    public class Employee : User
    {

        #region Properties
        public int Savings { get; set; }
        public int RedeemedMinutes { get; set; }
        public int BalanceMinutes { get; set; }
        public int BaseMinutes { get; set; }
        public int PedagogicalQualificationMinutes { get; set; }
        public bool IsGroupLeader { get; set; }
        public bool IsAssistantProfessor { get; set; }
        public List<IWorkAssignment> Assignments { get; set; }
        public List<Programme> Programmes { get; set; }
         #endregion

        #region Constructors

        #endregion

        #region Methods
        public override ClaimsPrincipal GetClaimsPrinciple()
        {
            return null;
        }

        public int GetTotalMinutes()
        {
            return 0;
        }

        public int GetTotalCourseMinutes()
        {
            return 0;
        }

        public int GetTotalSupervisionMinutes()
        {
            return 0;
        }

        public int GetTotalExamMinutes()
        {
            return 0;
        }

        public int GetTotalMiscMinutes()
        {
            return 0;
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
