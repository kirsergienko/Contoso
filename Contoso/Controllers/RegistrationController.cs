using Contoso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Contoso.Controllers
{
    public class RegistrationController : ApiController
    {
        MyDbContext context = new MyDbContext();
        List<RegistrationByMonth> registrations = new List<RegistrationByMonth>();

        // GET: api/Registration
        public List<RegistrationByMonth> Get()
        {
            foreach (var item in context.RegistrationsByMonth)
            {
                registrations.Add(item);
            }

            return registrations;
        }
        
        [Route("api/registration/bymonth/{month}")]
        [HttpGet]
        public List<RegistrationByMonth> ByMonths(string month)
        {
            int Year = int.Parse(month.Substring(0, 4));

            int x = int.Parse(month.Substring(4, 2));

            string _Month = MonthIntToString(x);

            foreach (var item in context.RegistrationsByMonth.Where(x => x.Month == _Month).Where(x => x.Year == Year))
            {
                registrations.Add(item);
            }

            return registrations;
        }

        [Route("api/registration/bymonth")]
        [HttpGet]
        public List<RegistrationByMonth> ByMonths()
        {
            foreach (var item in context.RegistrationsByMonth.Where(x => x.Month == "December"))
            {
                registrations.Add(item);
            }

            return registrations;
        }

        public string MonthIntToString(int month)
        {
            switch (month)
            {
                case 1: return "January";
                case 2: return "February ";
                case 3: return "March";
                case 4: return "April";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November ";
                case 12: return "December";
                default: return "December";
            }

        }

     
    }
}
