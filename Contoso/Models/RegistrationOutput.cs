using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Contoso.Models
{
    [DataContract]
    public class RegistrationOutput
    {
        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public int Month { get; set; }

        [DataMember]
        public int Users { get; set; }

        [DataMember]
        public List<Device> Devices { get; set; }
    }
}