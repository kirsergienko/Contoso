using System;

namespace Contoso.Models
{
    public class SessionDuration
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Hour { get; set; }

        public int DurationInMinutes { get; set; }

        public int TotalDuration { get; set; }
    }
}