using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatlyServices.Repository
{
    public class UserRepository : IUserRepository
    {
        private ChatlyEntities context = null;

        public UserRepository()
        {
            context = new ChatlyEntities();
        }
        public IEnumerable<AspNetUsers> GetUsersList()
        {
            return context.AspNetUsers.ToList();
        }
    }
}