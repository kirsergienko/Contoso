using System;

namespace Contoso.Models
{
    public class SessionForHour
    {
        public int Id { get; set; }

        public DateTime Hour { get; set; }

        public int MaxSessions { get; set; }
    }
}