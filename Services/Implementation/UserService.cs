
using LibraryApp.Context;
using LibraryApp.Models;
using System.Linq;

namespace LibraryApp.Services
{
    public class UserService : IUserService
    {
        private readonly LibraryContext _context;
        public UserService(LibraryContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            _context.Users.Add(user);
            user.UserId = _context.SaveChanges();

            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }
    }
}