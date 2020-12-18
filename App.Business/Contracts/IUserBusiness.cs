using App.Business.Models;
using System.Collections.Generic;

namespace App.Business
{
    public interface IUserBusiness
    {
        User GetUser(int userId);
        List<User> GetUsers(int userId);
    }
}