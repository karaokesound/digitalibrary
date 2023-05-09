using Library.Data;
using Library.UI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Library.UI.Services
{
    public class UserRepository : IUserRepository
    {
        private LibraryDbContext context;

        

        public UserRepository(LibraryDbContext context)

        {

            this.context = context;

        }



        public IEnumerable<UserModel> GetUsers()

        {

            return context.Users.ToList();

        }

        public UserModel GetUserByID(int userId)

        {

            return context.Users.Find(userId);

        }



        public void InsertUser(UserModel user)

        {

            context.Users.Add(user);

        }



        public void DeleteUser(int userId)

        {

            UserModel user = context.Users.Find(userId);

            context.Users.Remove(user);

        }



        public void UpdateUser(UserModel user)

        {

            context.Entry(user).State = EntityState.Modified;

        }



        public void Save()

        {

            context.SaveChanges();

        }

        IEnumerable IUserRepository.GetUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}
