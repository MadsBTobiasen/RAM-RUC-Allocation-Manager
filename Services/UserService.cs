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
        //private DbService<User> dbService;
        #endregion

        #region Properties
        public List<User> Users { get; set; }
        #endregion

        #region Constructor

        #endregion

        #region Methods
        public List<User> GetUsers()
        {
            return Users;
        }

        public User GetUserByID(int id)
        {
            return null;
        }

        public User CreateUser(User userToAdd)
        {
            return null;
        }

        public User EditUser(User userToEdit)
        {
            return null;
        }

        public User DeleteUser(User userToDelete)
        {
            return null;
        }

        #endregion

    }
}
