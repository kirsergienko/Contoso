using Contoso.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Contoso.Controllers
{
    public class RegistrationController : ApiController
    {
        MyDbContext context = new MyDbContext();
        List<RegistrationByMonth> registrations = new List<RegistrationByMonth>();

        [System.Web.Http.Route("api/registration/bymonth/{month}")]
        [System.Web.Http.HttpGet]
        public ActionResult ByMonths(string month)
        {
            int Year = int.Parse(month.Substring(0, 4));

            int _Month = int.Parse(month.Substring(4, 2));

            return CreateOutput(Year, _Month);

        }

        [System.Web.Http.Route("api/registration/bymonth")]
        [System.Web.Http.HttpGet]
        public ActionResult ByMonths()
        {
            return CreateOutput(2021, 12);
        }


        public ActionResult CreateOutput(int Year, int _Month)
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
                JsonResult jsonResult = new JsonResult();

                jsonResult.Data = new RegistrationOutput { Month = _Month, Year = Year, Users = registredUsers, Devices = devices };

                return jsonResult;
            }
            else
            {
                return new HttpNotFoundResult();
            }

        }

    }
}
