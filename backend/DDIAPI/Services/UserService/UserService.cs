using Microsoft.EntityFrameworkCore;
using DDIAPI.Models;

namespace DDIAPI.Services; 
    public class UserService : IUserService {
    //     public User? Authenticate(string username, string password) {
    //         if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) {
    //             return null;
    //         }
    //         var user = _context.Users.SingleOrDefault(x => x.Username == username);
    //         if (user == null) {
    //             return null;
    //         }
    //         if (!VerifyPassword(password)) {
    //             return null;
    //         }
    //         return user;
    //     }

    // private async bool VerifyPassword(string password)
    // {
    //     await _context.Users.FindAsync(id);
    //     if (user.password == password) {
    //         return true;
    //     }
    // }
}