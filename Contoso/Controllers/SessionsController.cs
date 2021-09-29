using Contoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contoso.Controllers
{
    public class SessionsController : ApiController
    {
        MyDbContext context = new MyDbContext();

        [Route("api/sessions/byhour")]
        [HttpGet]
        public object GetAllData()
        {
            List<Date> dates = new List<Date>();

            foreach (var item in context.SessionsDuration)
            {
                    dates.Add(new Date
                    {
                        Hour = DateTime.Parse($"{item.Date.ToString("yyyy-MM-dd")} {item.Hour}:00:00"),
                        TotalTimeForHour = item.DurationInMinutes,
                        QumulativeForHour = item.TotalDuration
                    });
            }
            foreach (var item in context.SessionsForHour)
            {
                foreach (var date in dates)
                {
                    if (date.Hour == item.Hour)
                    {
                        date.ConcurrentSessions = item.MaxSessions;
                    }
                }
            }

            return new SessionsOutput { Dates = dates };
        }
    }
}
