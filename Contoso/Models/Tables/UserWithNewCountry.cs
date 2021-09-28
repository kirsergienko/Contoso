using System;

namespace Contoso.Models
{
    public class UserWithNewCountry
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Country { get; set; }

        public DateTime LoginTime { get; set; }
    }
}