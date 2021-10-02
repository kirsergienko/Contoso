using Contoso.Controllers;
using Contoso.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace Contoso.Tests
{
    public class RegistrationControllerTests
    {
        [Fact]
        public void ByMonth()
        {
            //Arrange
            RegistrationOutput _expected = new RegistrationOutput
            {
                Year = 2020,
                Month = 8,
                Users = 26,
                Devices = new List<Device>
                {
                   new Device {
                                 DeviceType = "Laptop",
                                 Value = 1
                              },
                   new Device {
                                 DeviceType = "Mobile phone",
                                 Value = 1
                              } 
                }
            };
            //Act
            var result = new RegistrationController().ByMonths();
            string jsonresult = JsonConvert.SerializeObject(result);
            RegistrationOutput _actual = JsonConvert.DeserializeObject<RegistrationOutput>(jsonresult);

            //Assert
            string expected = $"{_expected.Year}{_expected.Month}{_expected.Users}";
            foreach (var item in _expected.Devices)
            {
                expected += item.DeviceType;
                expected += item.Value;
            }
            string actual = $"{_actual.Year}{_actual.Month}{_actual.Users}";
            foreach (var item in _actual.Devices)
            {
                actual += item.DeviceType;
                actual += item.Value;
            }

            Assert.Equal(expected, actual);
        }
    }
}
