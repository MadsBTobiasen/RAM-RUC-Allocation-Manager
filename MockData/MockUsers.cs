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

                    users.Add(new Leader() { ID = i + 10000, Name = $"Leader_{i}", Password = "lea", Type = User.UserType.Leader });

                }

                for (int i = 0; i < 100; i++)
                {

                    users.Add(new Employee() { ID = i + 1000, Name = $"Employee_{i}", Password = "emp", Type = User.UserType.Employee });

                }

            }

            return users;

        }

    }
}
