using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.Models;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments.Committee;

namespace RAM___RUC_Allocation_Manager.MockData
{
    public class FalkesMockdata
    {
        public void CreateMockData()
        {
            //Users
            Employee Falke = new Employee();
            Falke.Name = "Falke";
            Falke.Email = "Falke@mail.dk";
            Falke.Username = "FalkeUsername";
            Falke.Password = "FalkePassword";
            Falke.Title = Employee.EmployeeTitle.Professor;
            Falke.IsGroupLeader = true;
            Falke.Balance = 0;
            Falke.Savings = Employee.EmployeeSavings.ZeroPercent;

            Employee Mads = new Employee();
            Mads.Name = "Mads";
            Mads.Email = "Mads@mail.dk";
            Mads.Username = "MadsUsername";
            Mads.Password = "MadsPassword";
            Mads.Title = Employee.EmployeeTitle.AssistantProfessor;
            Mads.IsGroupLeader = false;
            Mads.Balance = 60;
            Mads.Savings = Employee.EmployeeSavings.FortyPercent;

            Leader Martin = new Leader();
            Martin.Name = "Martin";
            Martin.Email = "Martin@Mail.dk";
            Martin.Username = "MatinUsername";
            Martin.Password = "MartinPassword";
            Martin.IsAdmin = true;

            Leader Simon = new Leader();
            Simon.Name = "Simon";
            Simon.Email = "Simon@mail.dk";
            Simon.Username = "SimonUsername";
            Simon.Password = "SimonPassword";
            Simon.IsAdmin = false;

            //Programmes
            Programme ComputerScience = new Programme();
            ComputerScience.Name = "Computer science";

            Programme Sociology = new Programme();
            Sociology.Name = "Sociology";

            Programme Medicine = new Programme();
            Medicine.Name = "Medicine";

            Programme MultimediaDesign = new Programme();
            MultimediaDesign.Name = "Multimedia Design";

            //Committees
            CustomCommittee CustomCommittee = new CustomCommittee();
            CustomCommittee.Name = "Test Custom committee";
            CustomCommittee.MinuteWorth = 240;
        }
    }
}
