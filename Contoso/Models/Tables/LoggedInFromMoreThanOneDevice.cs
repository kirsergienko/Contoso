using System;

namespace Contoso.Models
{
    public class LoggedInFromMoreThanOneDevice
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string DeviceName { get; set; }

        public DateTime LoginTime { get; set; }
    }
}