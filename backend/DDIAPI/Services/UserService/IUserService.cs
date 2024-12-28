using DDIAPI.Models;
using System;
namespace DDIAPI.Services;
public interface IUserService {
    public User? Authenticate(string username, string password);
    public User GetById(int id);
    public User Create(User user, string password);
    public void Update(User user, string password = null);
    public void Delete(int id);
}