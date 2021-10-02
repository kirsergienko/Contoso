using Contoso.Controllers;
using Contoso.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xunit;

namespace Contoso.Tests
{
    public class SessionsControllerTests
    {
        [Fact]
        public void ByHour()
        {
            //Arrange
            SessionsOutput _expected = new SessionsOutput
            {
                Dates = new List<Date>
                {
                    new Date {
                               Hour = DateTime.Parse("2021-06-29T00:00:00"),
                               ConcurrentSessions = 0,
                               TotalTimeForHour = 500,
                               QumulativeForHour = 500
                             },
                    new Date {
                               Hour = DateTime.Parse("2021-06-29T01:00:00"),
                               ConcurrentSessions = 0,
                               TotalTimeForHour = 342,
                               QumulativeForHour = 842
                             },
                    new Date {
                                Hour = DateTime.Parse("2021-06-29T02:00:00"),
                                ConcurrentSessions = 0,
                                TotalTimeForHour = 100,
                                QumulativeForHour = 942
                             }
                }
            };
            //Act
            var result = new SessionsController().StartAndEndPoints("2021-06-29T00:00:00", "2021-06-29T03:00:00");
            string jsonresult = JsonConvert.SerializeObject(result);
            SessionsOutput _actual = JsonConvert.DeserializeObject<SessionsOutput>(jsonresult);

            //Assert
            string expected = "";
            foreach (var item in _expected.Dates)
            {
                expected += item.Hour;
                expected += item.ConcurrentSessions;
                expected += item.TotalTimeForHour;
                expected += item.QumulativeForHour;
            }
            string actual = "";
            foreach (var item in _actual.Dates)
            {
                actual += item.Hour;
                actual += item.ConcurrentSessions;
                actual += item.TotalTimeForHour;
                actual += item.QumulativeForHour;
            }

            Assert.Equal(expected, actual);
        }
    }
}

