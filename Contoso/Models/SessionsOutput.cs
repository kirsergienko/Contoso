using System;
using System.Collections.Generic;

namespace Contoso.Models
{
    public class SessionsOutput
    {
        public List<Date> Dates { get; set; }
    }

    public class Date 
    {
        public DateTime Hour { get; set; }

        public int ConcurrentSessions { get; set; }

        public int TotalTimeForHour { get; set; }

        public int QumulativeForHour { get; set; }
    }

}