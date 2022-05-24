//using Microsoft.AspNetCore.Identity;
//using RAM___RUC_Allocation_Manager.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using RAM___RUC_Allocation_Manager.Models.DbConnections;

//namespace RAM___RUC_Allocation_Manager.MockData
//{
//    public static class MockUsers
//    {

//        private static int leaderStartId = 10000;
//        private static int employeeStartId = 20000;
//        private static int miscStartId = 30000;
//        private static PasswordHasher<string> hasher = new PasswordHasher<string>();
//        private static List<User> users;
//        private static List<Leader> leaders;

//        public static List<User> GetUsers()
//        {

//            if (users == null || users.Count == 0)
//            {

//                List<Employee> employees = new List<Employee>();
//                List<Leader> leaders = new List<Leader>();
//                users = new List<User>();

//                List<Employee> mockTestEmployee = GetMockTestEmployee();
//                List<User> mockTestLeader = GetMockTestLeader();

//                employees.AddRange(AddEmployees(100, "Emp"));
//                leaders.AddRange(AddLeaders(25, "Lea"));

//                for(int i = 0; i < employees.Count; i++)
//                {
                    
//                    Employee emp = employees[i];
//                    int random = new Random().Next(0, leaders.Count - 1);
//                    AddEmployeeToLeaderProgrammes(leaders[random], emp);

//                }

//                for(int i = 0; i < leaders.Count; i++)
//                {

//                    Leader lead = leaders[i];
//                    if(i%5 == 0)
//                    {
//                        lead.Programmes[0].Users.Add(mockTestEmployee[0]);
//                    }

//                }

//                users.AddRange(mockTestEmployee);
//                users.AddRange(mockTestLeader);
//                users.AddRange(employees);
//                users.AddRange(leaders);

//            }

//            //Below LINQ to ensure only unique Ids are returned.
//            return users.GroupBy(i => i.Id).Select(g => g.First()).ToList();

//        }
//        private static List<Employee> GetMockTestEmployee()
//        {

//            Employee employee = new Employee()
//            {
//                Id = 299,
//                Name = "Employee1000",
//                Username = "Employee1000"
//            };

//            employee.SetPassword("Password");

//            Group Group = new Group();

//            EmployeeGroup employeeGroupOne = new EmployeeGroup()
//            { Employee = employee, Group = Group, RoleOfEmployee = EmployeeGroup.EmployeeRole.Supervisor };
//            EmployeeGroup employeeGroupTwo = new EmployeeGroup()
//            { Employee = employee, Group = Group, RoleOfEmployee = EmployeeGroup.EmployeeRole.Supervisor };
//            Group.Id = 1;
//            Group.RucId = 1;
//            Group.EmployeeGroups.Add(employeeGroupOne);
//            Group.IsMasterThesis = true;
//            Group.MemberAmount = 4;
//            Group.EmployeeGroups.Add(employeeGroupTwo);
//            employee.EmployeeGroups.Add(employeeGroupOne);
//            employee.EmployeeGroups.Add(employeeGroupTwo);

//            return new List<Employee>() { employee };

//        }
//        private static List<Employee> AddEmployees(int itterations, string namePrefix)
//        {

//            List<Employee> output = new List<Employee>();

//            for (int i = 0; i < itterations; i++)
//            {

//                Employee emp = new Employee() { Id = ++employeeStartId, Username = $"{namePrefix + i}", Name = $"{namePrefix + i}" };
//                emp.SetPassword("emp");

//                output.Add(emp);

//            }

//            return output;

//        }
//        private static List<User> GetMockTestLeader()
//        {

//            Leader leader = new Leader()
//            {
//                Id = 10,
//                Name = "Leader1000",
//                Username = "Leader1000"
//            };

//            leader.SetPassword("Password");

//            Programme programme1 = new Programme()
//            {
//                Id = ++miscStartId,
//                Name = "Test Studie 1",
//                Users = AddEmployees(50, "pro1_emp_").Cast<User>().ToList()
//            };

//            Programme programme2 = new Programme()
//            {
//                Id = ++miscStartId,
//                Name = "Test Studie 2",
//                Users = AddEmployees(50, "pro2_emp_").Cast<User>().ToList()
//            };

//            leader.Programmes = new List<Programme>
//            {
//                programme1,
//                programme2
//            };

//            List<User> usersToAdd = new List<User>() { leader };

//            usersToAdd.AddRange(programme1.Users);
//            usersToAdd.AddRange(programme2.Users);

//            //Below LINQ to ensure only unique Ids are returned.
//            return usersToAdd.GroupBy(i => i.Id).Select(g => g.First()).ToList();

//        }
//        private static List<Leader> AddLeaders(int itterations, string namePrefix)
//        {

//            List<Leader> output = new List<Leader>();

//            for (int i = 0; i < itterations; i++)
//            {

//                List<Programme> programmes = new List<Programme>() { new Programme() { Id = ++miscStartId, Name = $"Test Studie_{namePrefix + i}", Users = new List<User>() } };
//                Leader lead = new Leader() { Id = ++leaderStartId, Username = $"{namePrefix + i}", Name = $"{namePrefix + i}", Programmes = programmes };
//                lead.SetPassword("lea");

//                output.Add(lead);

//            }

//            return output;

//        }
//        private static void AddEmployeeToLeaderProgrammes(Leader leader, Employee employee)
//        {
//            leader.Programmes[0].Users.Add(employee);
//        }


//    }

//}