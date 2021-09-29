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
            DateTime start = DateTime.Parse("1000-01-01 12:00:00");

            DateTime end = DateTime.Parse("9999-01-01 12:00:00");

            return CreateResult(start, end);
        }

        [Route("api/sessions/byhour")]
        [HttpGet]
        public object StartAndEndPoints(string startTime, string endTime)
        {
            DateTime start = DateTime.Parse(startTime);

            DateTime end = DateTime.Parse(endTime);

            return CreateResult(start, end);
        }

        [Route("api/sessions/byhour")]
        [HttpGet]
        public object StartPoint(string startTime)
        {
            DateTime start = DateTime.Parse(startTime);

            DateTime end = DateTime.Parse("9999-01-01 12:00:00");

            return CreateResult(start, end);
        }

        [Route("api/sessions/byhour")]
        [HttpGet]
        public object EndPoint(string endTime)
        {
            DateTime start = DateTime.Parse("1000-01-01 12:00:00");

            DateTime end = DateTime.Parse(endTime);

            return CreateResult(start, end);
        }

        public object CreateResult(DateTime startTime, DateTime endTime)
        {
            List<Date> dates = new List<Date>();

            foreach (var item in context.SessionsDuration)
            {
                if (DateTime.Parse($"{item.Date.ToString("yyyy-MM-dd")} {item.Hour}:00:00").CompareTo(startTime) == 1 &&
                    DateTime.Parse($"{item.Date.ToString("yyyy-MM-dd")} {item.Hour}:00:00").CompareTo(endTime) == -1)
                {
                    dates.Add(new Date
                    {
                        Hour = DateTime.Parse($"{item.Date.ToString("yyyy-MM-dd")} {item.Hour}:00:00"),
                        TotalTimeForHour = item.DurationInMinutes,
                        QumulativeForHour = item.TotalDuration
                    });
                }
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
            if (dates.Count > 0)
            {
                return new SessionsOutput { Dates = dates };
            }
            else return new System.Web.Mvc.HttpNotFoundResult();
        }

        
    }
}
