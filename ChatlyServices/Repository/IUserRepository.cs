using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatlyServices.Repository
{
   
    public interface IUserRepository
    {
        Users Authenticate(string username, string password);
        
        Users Create(Users user, string password);
        void Delete(int id);
        bool UserExists(int userId);
        bool Save();
    }
}