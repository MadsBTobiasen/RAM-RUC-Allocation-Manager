using RAM___RUC_Allocation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RAM___RUC_Allocation_Manager.MockData;
using RAM___RUC_Allocation_Manager.Models.DbConnections;
using RAM___RUC_Allocation_Manager.Models.WorkAssigments;
using Employee = RAM___RUC_Allocation_Manager.Models.Employee;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class UserService
    {

        #region Fields

        private UserDbService userDbService;
        #endregion

        #region Properties
        public List<User> Users { get; set; }
        public ICollection<Programme> Programmes { get; set; }

        #endregion

        #region Constructor
        public UserService(UserDbService userDbService)
        {

            this.userDbService = userDbService;
            //TODO: Retrieve Users from DB-Service.
            //Users = userDbService.GetEmployeesWithNavPropsAsync().Result.ToList().Concat(userDbService.GetLeadersWithNavProps().Result.ToList()).ToList();
            Users = userDbService.GetObjectsAsync().Result.ToList();
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

        public Programme GetProgrammeByID(int id)
        {
            return Programmes.Where(p => p.Id == id).Select(p => p).FirstOrDefault();
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

        public async Task<User> GetUserWithNavPropById(int id)
        {
            User user;
            if (Users.Where(u => u.Id == id).Select(u => u.Type).FirstOrDefault() == User.UserType.Employee)
            { 
                user = await userDbService.GetEmployeeById(id);
            }
            else
            {
                user = await userDbService.GetLeaderById(id);
            }

            return user;
        }


        /// <summary>
        /// Method that adds a given user to the List.
        /// </summary>
        /// <param name="userToAdd">User object to add.</param>
        /// <returns>The added user object.</returns>
        public async Task<User> CreateUser(User userToAdd)
        {
            Users.Add(userToAdd);

            await userDbService.AddObjectAsync(userToAdd);
            return userToAdd;
        }

        /// <summary>
        /// Method that edits a user object, by trying to match an incoming user-id with one in the list of Users,
        /// if theres a match, that user in the list, gets updated with the properties of the userToEdit object.
        /// </summary>
        /// <param name="userToEdit">User object to update with.</param>
        /// <returns>Returns a user-object, the object is null if the edit failed, and the updated user if the update was succesfull.</returns>
        public async Task<User> EditUser(User editedUser)
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
                    (userToEdit as Employee).AssistantProfessorSupervisions =
                        (editedUser as Employee).AssistantProfessorSupervisions;
                    (userToEdit as Employee).SynopsisExaminations = (editedUser as Employee).SynopsisExaminations;
                    (userToEdit as Employee).PortfolioExaminations = (editedUser as Employee).PortfolioExaminations;
                    (userToEdit as Employee).PhdCommittees = (editedUser as Employee).PhdCommittees;
                    (userToEdit as Employee).Balance = (editedUser as Employee).Balance;
                    (userToEdit as Employee).IsGroupLeader = (editedUser as Employee).IsGroupLeader;
                    (userToEdit as Employee).Savings = (editedUser as Employee).Savings;
                }

                if (userToEdit is Leader)
                {
                    (userToEdit as Leader).IsAdmin = (userToEdit as Leader).IsAdmin;
                }

            }


            await userDbService.UpdateObjectAsync(editedUser);
          
            return userToEdit;

        }


        /// <summary>
        /// Method that "deletes" a user object, by replacing it with the given argument, if the two objects have a matching id.
        /// </summary>
        /// <param name="userToEdit">User object to delete with.</param>
        /// <returns>Returns a user-object, the object is null if the delete failed, and the deletedUser if the update was succesfull.</returns>
        public async Task<User> DeleteUser(User userToDelete)
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

            await userDbService.DeleteObjectAsync(userToDelete);
            return deletedUser;
            //dbService.DeleteObjectAsync(userToDelete);
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
