using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySite.Models;

namespace MySite.DAL
{
    public class EF_UserRepository : IUserRepository
    {
        private DbConnectionContext db = new DbConnectionContext();

        public void CreateNewUser(User userToCreate)
        {
            db.Users.Add(userToCreate);
            db.SaveChanges();
        }

        public void EditUser(User userToEdit)
        {
            db.Entry(userToEdit).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.ToList();
        }




    }
}