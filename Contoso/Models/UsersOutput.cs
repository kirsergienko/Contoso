using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso.Models
{
    public class UsersOutput
    {
        public List<User> Users;
    }

    public class User
    {
        public string UserName { get; set; }

        public string Device { get; set; }

        public DateTime LoginTime { get; set; }

        public UnexceptedLogin UnexceptedLogin { get; set; }
    }

    public class UnexceptedLogin
    {
        public string Country { get; set; }

        public DateTime LoginTime { get; set; }
    }
}