using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySite.Models;

namespace MySite.DAL
{
    public interface IUserRepository
    {
        void CreateNewUser(User userToCreate);
        void EditUser(User userToEdit);
        void DeleteUser(int id);
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();

    }
}