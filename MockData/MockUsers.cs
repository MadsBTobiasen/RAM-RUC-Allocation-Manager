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

            if(users == null || users.Count == 0)
            {

                users = new List<User>();

                for(int i = 0; i < 25; i++)
                {

                    users.Add(new Leader() { Id = i + 10000, Name = $"Leader_{i}", Username = $"Leader_{i}", Password = hasher.HashPassword(null, "lea") });

                }

                for (int i = 0; i < 100; i++)
                {

                    users.Add(new Employee() { Id = i + 20000, Name = $"Employee_{i}", Username = $"Employee_{i}", Password = hasher.HashPassword(null, "emp") });

                }

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
                Users = new List<User>()
            {
                new Employee() { Id = 4400, Name = "Empl1", Username = "Empl1", Password = hasher.HashPassword(null, "emp") },
                new Employee() { Id = 4401, Name = "Empl2", Username = "Empl2", Password = hasher.HashPassword(null, "emp") },
                new Employee() { Id = 4402, Name = "Empl3", Username = "Empl3", Password = hasher.HashPassword(null, "emp") },
                new Employee() { Id = 4403, Name = "Empl4", Username = "Empl4", Password = hasher.HashPassword(null, "emp") }
    }
            };

            Programme programme2 = new Programme()
            {
                Id = 3001,
                Name = "Test Studie 2",
                Users = new List<User>()
            {
                new Employee() { Id = 4400, Name = "Empl5", Username = "Empl5", Password = hasher.HashPassword(null, "emp") },
                new Employee() { Id = 4401, Name = "Empl6", Username = "Empl6", Password = hasher.HashPassword(null, "emp") },
                new Employee() { Id = 4402, Name = "Empl7", Username = "Empl7", Password = hasher.HashPassword(null, "emp") },
                new Employee() { Id = 4403, Name = "Empl8", Username = "Empl8", Password = hasher.HashPassword(null, "emp") }
            }
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

            return new List<User>() { employee };

        }

    }

}