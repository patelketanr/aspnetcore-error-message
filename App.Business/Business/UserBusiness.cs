using App.Business.Models;
using App.Core.BusinessExceptions;
using System;
using System.Collections.Generic;

namespace App.Business
{
    public class UserBusiness : IUserBusiness
    {
        public User GetUser(int userId)
        {
            if (userId == 0)
            {
                throw new BusinessRuleException("Invalid userid");
            }
            return new User();
        }

        public List<User> GetUsers(int userId)
        {
            if (userId == 0)
            {
                var listError = new List<object>(){new { Error ="User FirstName is Invalid" },
                                                   new { Error ="User LastName is Invalid" }
                                                  };
                throw new BusinessRuleException("Invalid User", listError);
            }

            return new List<User>();
        }

    }
}
