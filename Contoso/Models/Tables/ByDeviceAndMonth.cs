namespace Contoso.Models
{ 
    public class ByDeviceAndMonth
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public string DeviceType { get; set; }

        public int NumberOfUsers { get; set; }
    }
}