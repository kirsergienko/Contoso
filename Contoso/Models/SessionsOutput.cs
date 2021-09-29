using System;
using System.Collections.Generic;

namespace Contoso.Models
{
    /// <summary>
    /// Model of sessions data.
    /// </summary>
    public class SessionsOutput
    {   /// <summary>
        /// List of dates.
        /// </summary>
        public List<Date> Dates { get; set; }
    }
    /// <summary>
    /// Model of one date.
    /// </summary>
    public class Date
    {
        /// <summary>
        /// Hour of session
        /// </summary>
        public DateTime Hour { get; set; }
        /// <summary>
        /// Count of paralel sessions.
        /// </summary>
        public int ConcurrentSessions { get; set; }
        /// <summary>
        /// Total session duration for hour (in minutes).
        /// </summary>
        public int TotalTimeForHour { get; set; }
        /// <summary>
        /// Total session duration (accumulated).
        /// </summary>
        public int QumulativeForHour { get; set; }
    }

}