using Contoso.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace Contoso.Controllers
{
    /// <summary>
    /// A controller that outputs information about users and devices, sorted by month, in JSON format.
    /// </summary>

    public class RegistrationController : ApiController
    {
        MyDbContext context = new MyDbContext();

        /// <summary>
        /// Gets information about users and their device, grouped by selected month.
        /// </summary>
        /// <param name="month">Month by which the records will be grouped.</param>
        /// <returns>Information about users and their devices for one month in JSON format.</returns>
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
        /// <summary>
        /// Gets information about users and their device, grouped by default month.
        /// </summary>
        /// <returns>Information about users and their devices for default month in JSON format.</returns>
        [Route("api/registration/bymonth")]
        [HttpGet]
        public object ByMonths()
        {
            return CreateOutput(2020, 08);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
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
