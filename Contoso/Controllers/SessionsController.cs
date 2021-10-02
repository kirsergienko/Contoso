using Contoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Contoso.Controllers
{
    /// <summary>
    /// Login hourly stats endpoint returning number of concurrent logins, total session time for the hour, and
    /// cumulative time for the hour.Request should accept start and end time parameters.Both parameters are
    /// optional. Example of point: "2021-01-01 12:00:00".
    /// </summary>
    public class SessionsController : ApiController
    {
        MyDbContext context = new MyDbContext();

        /// <summary>
        /// Gets information about all available data.
        /// </summary>
        /// <returns>Infromation about sessions in JSON format.</returns>
        [Route("api/sessions/byhour")]
        [HttpGet]
        public object GetAllData()
        {
            DateTime start = DateTime.Parse("1000-01-01 12:00:00");

            DateTime end = DateTime.Parse("9999-01-01 12:00:00");

            return CreateResult(start, end);
        }
        /// <summary>
        /// Gets information about data definited by start and end points. 
        /// </summary>
        /// <param name="startTime">Start point</param>
        /// <param name="endTime">End point</param>
        /// <returns>Infromation about sessions in selected period in JSON format.</returns>
        [Route("api/sessions/byhour")]
        [HttpGet]
        public object StartAndEndPoints(string startTime, string endTime)
        {
            DateTime start;

            DateTime end;
            try
            {
                start = DateTime.Parse(startTime);

                end = DateTime.Parse(endTime);
            }
            catch
            {
                return CreateResult(DateTime.Parse("1000-01-01 12:00:00"), DateTime.Parse("9999-01-01 12:00:00"));
            }


            return CreateResult(start, end);
        }
        /// <summary>
        /// Gets information about data definited by only start point.
        /// </summary>
        /// <param name="startTime">Start point</param>
        /// <returns>Infromation about sessions that were after start point in JSON format.</returns>
        [Route("api/sessions/byhour")]
        [HttpGet]
        public object StartPoint(string startTime)
        {
            DateTime start;

            DateTime end;
            try
            {
                start = DateTime.Parse(startTime);

                end = DateTime.Parse("9999-01-01 12:00:00");
            }
            catch
            {
                return CreateResult(DateTime.Parse("1000-01-01 12:00:00"), DateTime.Parse("9999-01-01 12:00:00"));
            }

            return CreateResult(start, end);
        }
        /// <summary>
        /// Gets information about data definited by only end point.
        /// </summary>
        /// <param name="endTime">End point</param>
        /// <returns>Infromation about sessions that were before end point in JSON format.</returns>
        [Route("api/sessions/byhour")]
        [HttpGet]
        public object EndPoint(string endTime)
        {
            DateTime start;

            DateTime end;
            try
            {
                start = DateTime.Parse("1000-01-01 12:00:00");

                end = DateTime.Parse(endTime);
            }
            catch
            {
                return CreateResult(DateTime.Parse("1000-01-01 12:00:00"), DateTime.Parse("9999-01-01 12:00:00"));
            }

            return CreateResult(start, end);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public object CreateResult(DateTime startTime, DateTime endTime)
        {
            List<Date> dates = new List<Date>();

            foreach (var item in context.SessionsDuration)
            {
                if (DateTime.Parse($"{item.Date.ToString("yyyy-MM-dd")} {item.Hour}:00:00").CompareTo(startTime) >= 0 &&
                    DateTime.Parse($"{item.Date.ToString("yyyy-MM-dd")} {item.Hour}:00:00").CompareTo(endTime) <= 0)
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

            return new SessionsOutput { Dates = dates };

        }


    }
}
