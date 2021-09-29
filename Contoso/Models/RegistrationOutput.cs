using System.Collections.Generic;

namespace Contoso.Models
{
    public class RegistrationOutput
    {
        public int Year { get; set; }

        public int Month { get; set; }

        public int Users { get; set; }

        public List<Device> Devices { get; set; }
    }

    public class Device
    {
        public string DeviceType { get; set; }

        public int Value { get; set; }
    }
}