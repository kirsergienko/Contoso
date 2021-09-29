using Contoso.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Contoso.Controllers
{
    /// <summary>
    /// List of users and devices with concurrent logins extended with the last occurence of the login from unexpected country.
    /// </summary>
    public class UsersController : ApiController
    {
        MyDbContext context = new MyDbContext();

        /// <summary>
        /// Gets information about all anomalies.
        /// </summary>
        /// <returns>Information about logins with different devices and new countries in JSON format.</returns>
        [Route("api/users/anomalies")]
        [HttpGet]
        public object Get()
        {
            return CreateResult();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
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
