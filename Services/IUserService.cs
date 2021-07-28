
using LibraryApp.Models;

namespace LibraryApp.Services
{
    public interface IUserService
    {
        User Create(User user);
        User GetByEmail(string email);
        User GetById(int id);
    }
}