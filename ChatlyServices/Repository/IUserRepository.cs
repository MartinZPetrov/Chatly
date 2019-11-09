using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatlyServices.Repository
{
    public interface IUserRepository
    {
        IEnumerable<AspNetUsers> GetUsersList();
    }
}