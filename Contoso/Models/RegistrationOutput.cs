using System.Collections.Generic;

namespace Contoso.Models
{
    /// <summary>
    /// Model of registration data.
    /// </summary>
    public class RegistrationOutput
    {
        /// <summary>
        /// Year of registration.
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Month of registration.
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// Count of users.
        /// </summary>
        public int Users { get; set; }

        /// <summary>
        /// List of devices.
        /// </summary>
        public List<Device> Devices { get; set; }
    }
    /// <summary>
    /// Model of device.
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Device type.
        /// </summary>
        public string DeviceType { get; set; }
        /// <summary>
        /// Count of devices.
        /// </summary>
        public int Value { get; set; }
    }
}