using Contoso.Controllers;
using Contoso.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace Contoso.Tests
{
    public class UsersControllerTests
    {
        [Fact]
        public void Anomalies()
        {
            //Arrange
            UsersOutput _expected = new UsersOutput
            {
                Users = new List<User>
                {
                    new User
                    {
                        UserName = "John Doe",
                        Device = "John's Laptop",
                        LoginTime = DateTime.Parse("2021-07-01T17:35:18"),
                        UnexceptedLogin = new UnexceptedLogin 
                        {
                             Country = "Switzerland",
                             LoginTime = DateTime.Parse("2021-07-01T17:35:18")
                        }
                    },
                    new User
                    {
                        UserName = "John Doe",
                        Device = "John's Mobile phone",
                        LoginTime = DateTime.Parse("2021-07-01T17:55:47"),
                        UnexceptedLogin = new UnexceptedLogin
                        {
                             Country = "Switzerland",
                             LoginTime = DateTime.Parse("2021-07-01T17:35:18")
                        }
                    },
                    new User
                    {
                        UserName = "Kathy Johnson",
                        Device = "My Macbook",
                        LoginTime = DateTime.Parse("2021-07-01T18:11:23"),
                        UnexceptedLogin = new UnexceptedLogin
                        {
                             Country = "Turkey",
                             LoginTime = DateTime.Parse("2021-07-01T18:11:23")
                        }
                    },
                    new User
                    {
                        UserName = "Kathy Johnson",
                        Device = "My IPhone",
                        LoginTime = DateTime.Parse("2021-07-01T18:13:26"),
                        UnexceptedLogin = new UnexceptedLogin
                        {
                             Country = "Turkey",
                             LoginTime = DateTime.Parse("2021-07-01T18:11:23")
                        }
                    },
                    new User
                    {
                        UserName = "Kathy Johnson",
                        Device = "My IPad",
                        LoginTime = DateTime.Parse("2021-07-01T18:29:31"),
                        UnexceptedLogin = new UnexceptedLogin
                        {
                             Country = "Turkey",
                             LoginTime = DateTime.Parse("2021-07-01T18:11:23")
                        }
                    },
                }
            };
            //Act
            var result = new UsersController().Get();
            string jsonresult = JsonConvert.SerializeObject(result);
            UsersOutput _actual = JsonConvert.DeserializeObject<UsersOutput>(jsonresult);

            //Assert
            string expected = "";
            foreach (var item in _expected.Users)
            {
                expected += item.UserName;
                expected += item.Device;
                expected += item.LoginTime;
                expected += item.UnexceptedLogin.Country;
                expected += item.UnexceptedLogin.LoginTime;
            }
            string actual = "";
            foreach (var item in _actual.Users)
            {
                actual += item.UserName;
                actual += item.Device;
                actual += item.LoginTime;
                actual += item.UnexceptedLogin.Country;
                actual += item.UnexceptedLogin.LoginTime;
            }

            Assert.Equal(expected, actual);
        }
    }
}
