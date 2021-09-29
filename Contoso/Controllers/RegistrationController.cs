using Contoso.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Contoso.Controllers
{
    public class RegistrationController : ApiController
    {
        MyDbContext context = new MyDbContext();

        [Route("api/registration/bymonth/{month}")]
        [HttpGet]
        public object ByMonths(string month)
        {
            int Year;
            int _Month;
            try
            {
                Year = int.Parse(month.Substring(0, 4));

                _Month = int.Parse(month.Substring(4, 2));
            }
            catch
            {
                return new System.Web.Mvc.HttpNotFoundResult();
            }
            

            return CreateOutput(Year, _Month);

        }

        [Route("api/registration/bymonth")]
        [HttpGet]
        public object ByMonths()
        {
            return CreateOutput(2021, 12);
        }

        public object CreateOutput(int Year, int _Month)
        {
            int registredUsers = 0;

            List<Device> devices = new List<Device>();

            foreach (var item in context.ByDevicesAndMonths.Where(x => x.Month == _Month).Where(x => x.Year == Year))
            {
                registredUsers += item.NumberOfUsers;
            }
            foreach (var item in context.RegistrationsByMonth.Where(x => x.Month == _Month).Where(x => x.Year == Year))
            {
                registredUsers += item.NumberOfUsers;
            }
            foreach (var item in context.ByDevicesAndMonths.Where(x => x.Month == _Month).Where(x => x.Year == Year).GroupBy(x => x.DeviceType))
            {
                devices.Add(new Device { DeviceType = item.Key, Value = item.Count() });
            }
            if (registredUsers > 0)
            {
                return new RegistrationOutput { Month = _Month, Year = Year, Users = registredUsers, Devices = devices };
            }
            else
            {
                return new System.Web.Mvc.HttpNotFoundResult();
            }

        }

    }
}
