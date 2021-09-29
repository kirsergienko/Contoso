using Contoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contoso.Controllers
{
    public class UsersController : ApiController
    {
        MyDbContext context = new MyDbContext();

        [Route("api/users/anomalies")]
        [HttpGet]
        public object Get()
        {
            return CreateResult();
        }

        public object CreateResult()
        {
            List<User> users = new List<User>();

            foreach (var item in context.LoggedInFromMoreThanOneDevices)
            {
                users.Add(new User { UserName = item.UserName, Device = item.DeviceName, LoginTime = item.LoginTime });
            }

            foreach (var item in context.UsersWithNewCountry)
            {
                foreach (var user in users)
                {
                    if(user.UserName == item.UserName)
                    {
                        user.UnexceptedLogin = new UnexceptedLogin { Country = item.Country, LoginTime = item.LoginTime };
                    }
                }
            }

            return new UsersOutput { Users = users };
        }
    }
}
