using Microsoft.AspNetCore.Identity;
using RAM___RUC_Allocation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.MockData
{
    public static class MockUsers
    {

        private static PasswordHasher<string> hasher = new PasswordHasher<string>();
        private static List<User> users;

        public static List<User> GetUsers()
        {

            if (users == null || users.Count == 0)
            {

                users = new List<User>();

                users.AddRange(AddLeaders(25, 1000, "Lea"));
                users.AddRange(AddEmployees(100, 1000, "Emp"));

            }

            users.AddRange(GetMockTestLeader());
            users.AddRange(GetMockTestEmployee());

            //Below LINQ to ensure only unique Ids are returned.
            return users.GroupBy(i => i.Id).Select(g => g.First()).ToList();

        }

        private static List<User> GetMockTestLeader()
        {

            Leader leader = new Leader()
            {
                Id = 10,
                Name = "Leader1000",
                Username = "Leader1000",
                Password = hasher.HashPassword(null, "Password")
            };

            Programme programme1 = new Programme()
            {
                Id = 3000,
                Name = "Test Studie 1",
                Users = AddEmployees(50, 10000, "pro1_emp_")
            };

            Programme programme2 = new Programme()
            {
                Id = 3001,
                Name = "Test Studie 2",
                Users = AddEmployees(50, 20000, "pro2_emp_")
            };

            leader.Programmes = new List<Programme>
            {
                programme1,
                programme2
            };

            List<User> usersToAdd = new List<User>() { leader };

            usersToAdd.AddRange(programme1.Users);
            usersToAdd.AddRange(programme2.Users);

            //Below LINQ to ensure only unique Ids are returned.
            return usersToAdd.GroupBy(i => i.Id).Select(g => g.First()).ToList();

        }
        private static List<User> GetMockTestEmployee()
        {

            Employee employee = new Employee()
            {
                Id = 300,
                Name = "Employee1000",
                Username = "Employee1000",
                Password = hasher.HashPassword(null, "Password")
            };
            Group Group = new Group();
            Group.Id = 1;
            Group.RucId = 1;
            Group.InternalCensor = employee;
            Group.IsMasterThesis = true;
            Group.MemberAmount = 4;
            Group.Supervisor = employee;
            employee.Groups.Add(Group);
            return new List<User>() { employee };

        }

        private static List<User> AddEmployees(int itterations, int idStart, string namePrefix)
        {

            List<User> output = new List<User>();

            for (int i = 0; i < itterations; i++)
            {

                output.Add(new Employee() { Id = idStart + i, Username = $"{namePrefix + i}", Name = $"{namePrefix + i}", Password = hasher.HashPassword(null, "emp") });

            }

            return output;

        }
        private static List<User> AddLeaders(int itterations, int idStart, string namePrefix)
        {

            List<User> output = new List<User>();

            for (int i = 0; i < itterations; i++)
            {

                output.Add(new Leader() { Id = idStart + i, Username = $"{namePrefix + i}", Name = $"{namePrefix + i}", Password = hasher.HashPassword(null, "lea") });

            }

            return output;

        }

    }

}