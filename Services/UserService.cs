using RAM___RUC_Allocation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.MockData;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class UserService
    {

        #region Fields
        private DbService<User> dbService;
        #endregion

        #region Properties
        public List<User> Users { get; set; }
        public List<Employee> Employees  { get; set; }
        public List<EmployeeCourse> EmployeeCourses { get; set; }
        public Employee Employee { get; set; }

        #endregion

        #region Constructor
        public UserService(/*DbService<User> dbService*/)
        {

            //this.dbService = dbService;
            //TODO: Retrieve Users from DB-Service.
            Users = MockData.MockUsers.GetUsers();
            //Users = dbService.GetObjectsAsync().Result.ToList();
            Users = Users.OrderBy(u => u.Name).ToList();

        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that returns a List of all Users in the Users-list.
        /// </summary>
        /// <returns>List of User(s)</returns>
        public List<User> GetUsers()
        {
            return Users;
        }

        /// <summary>
        /// Method that returns a List of all users, with the given UserType.
        /// </summary>
        /// <param name="type">User.UserType to search for.</param>
        /// <returns>List of matched users.</returns>
        public List<User> GetUsersByType(User.UserType type)
        {
            return (from user in Users where user.Type == type select user).ToList(); 
        }

        /// <summary>
        /// Method that returns a User with the given ID.
        /// </summary>
        /// <param name="id">ID to search for.</param>
        /// <returns>Matched User.</returns>
        public User GetUserByID(int id)
        {
            //foreach (User user in Users)
            //{
            //    if (user.ID == id) return user;
            //}
            //return null;
            return (from user in Users where user.Id == id select user).SingleOrDefault();
        }


        /// <summary>
        /// Method that adds a given user to the List.
        /// </summary>
        /// <param name="userToAdd">User object to add.</param>
        /// <returns>The added user object.</returns>
        public User CreateUser(User userToAdd)
        {
            Users.Add(userToAdd);
            return userToAdd;
        }

        public Employee CreateEmployee(Employee employeeToAdd)
        {
            Users.Add(employeeToAdd);
            return employeeToAdd;
        }

        /// <summary>
        /// Method that edits a user object, by trying to match an incoming user-id with one in the list of Users,
        /// if theres a match, that user in the list, gets updated with the properties of the userToEdit object.
        /// </summary>
        /// <param name="userToEdit">User object to update with.</param>
        /// <returns>Returns a user-object, the object is null if the edit failed, and the updated user if the update was succesfull.</returns>
        public User EditUser(User editedUser)
        {

            User userToEdit = null;

            foreach(User u in Users)
            {
                if(u.Id == editedUser.Id)
                {

                    userToEdit = u;
                    break;

                }
            }

            if(userToEdit != null)
            {
                userToEdit.Name = editedUser.Name;
                userToEdit.Email = editedUser.Email;
                userToEdit.Type = editedUser.Type;
                userToEdit.Username = editedUser.Username;
                userToEdit.Password = editedUser.Password;
                
                if(userToEdit is Employee)
                {
                    (userToEdit as Employee).Title = (editedUser as Employee).Title;
                }

            }

            return userToEdit;

        }


        /// <summary>
        /// Method that "deletes" a user object, by replacing it with the given argument, if the two objects have a matching id.
        /// </summary>
        /// <param name="userToEdit">User object to delete with.</param>
        /// <returns>Returns a user-object, the object is null if the delete failed, and the deletedUser if the update was succesfull.</returns>
        public User DeleteUser(User userToDelete)
        {
            User deletedUser = null;

            foreach(User u in Users)
            {
                if(u.Id == userToDelete.Id)
                {
                    Users.Remove(u);
                    deletedUser = u;
                    break;

                }
            }
            return deletedUser;
        }

        /// <summary>
        /// Method that gets all the Leaders that a given employee has.
        /// </summary>
        /// <returns></returns>
        public List<Leader> GetEmployeeLeaders(int employeeId)
        {

            return GetUsersByType(User.UserType.Leader).Cast<Leader>()
                .Where(leader => leader.HasEmployeeInProgrammeById(employeeId))
                .GroupBy(leader => leader.Id)
                .Select(leader => leader.First())
                .ToList();

        }

        #endregion

    }
}
