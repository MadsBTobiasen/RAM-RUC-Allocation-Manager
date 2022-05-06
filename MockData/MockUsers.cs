using RAM___RUC_Allocation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.MockData
{
    public static class MockUsers
    {

        private static List<User> users;

        public static List<User> GetUsers()
        {

            if(users == null || users.Count == 0)
            {

                users = new List<User>();

                for(int i = 0; i < 25; i++)
                {

                    users.Add(new Leader() { ID = i + 10000, Name = $"Leader_{i}", Password = "lea" });

                }

                for (int i = 0; i < 100; i++)
                {

                    users.Add(new Employee() { ID = i + 20000, Name = $"Employee_{i}", Password = "emp" });

                }

            }

            users.Add(GetMockTestLeader());
            users.Add(GetMockTestEmployee());

            return users;

        }

        private static User GetMockTestLeader()
        {

            Leader leader = new Leader()
            {
                ID = 10,
                Name = "Leader_1000",
                Password = "Password",
            };

            Programme programme1 = new Programme()
            {
                ID = 3000,
                Name = "Test Studie 1",
                Users = new List<User>()
            {
                new Employee() { ID = 4400, Name = "Empl1", Password="emp", },
                new Employee() { ID = 4401, Name = "Empl2", Password="emp", },
                new Employee() { ID = 4402, Name = "Empl3", Password="emp", },
                new Employee() { ID = 4403, Name = "Empl4", Password="emp", }
            }
            };

            Programme programme2 = new Programme()
            {
                ID = 3001,
                Name = "Test Studie 2",
                Users = new List<User>()
            {
                new Employee() { ID = 4400, Name = "Empl5", Password="emp" },
                new Employee() { ID = 4401, Name = "Empl6", Password="emp" },
                new Employee() { ID = 4402, Name = "Empl7", Password="emp" },
                new Employee() { ID = 4403, Name = "Empl8", Password="emp" }
            }
            };

            leader.Programmes = new List<Programme>
            {
                programme1,
                programme2
            };

            return leader;

        }
        private static User GetMockTestEmployee()
        {

            Employee employee = new Employee()
            {
                ID = 300,
                Name = "Employee_1000",
                Password = "Password"
            };

            return employee;

        }

    }

}
