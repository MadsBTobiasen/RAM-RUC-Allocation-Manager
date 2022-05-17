using RAM___RUC_Allocation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class UserService
    {

        #region Fields
        private DbService<User> dbService;
        #endregion

        #region Properties
        public List<User> Users { get; set; }
        #endregion

        #region Constructor
        public UserService()
        {


            //TODO: Retrieve Users from DB-Service.
            Users = MockData.MockUsers.GetUsers();
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

        /// <summary>
        /// Method that "edits" a user object, by replacing it with the given argument, if the two objects have a matching id.
        /// </summary>
        /// <param name="userToEdit">User object to update with.</param>
        /// <returns>Returns a user-object, the object is null if the edit failed, and the updated user if the update was succesfull.</returns>
        public User EditUser(User userToEdit)
        {

            User editedUser = null;

            foreach(User u in Users)
            {
                if(u.Id == userToEdit.Id)
                {

                    Users.Remove(u);
                    Users.Add(userToEdit);
                    editedUser = userToEdit;

                    break;
                }
            }

            return editedUser;

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
