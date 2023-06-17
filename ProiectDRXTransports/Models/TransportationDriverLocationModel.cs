namespace ProiectDRXTransports.Models
{
    public class TransportationDriverLocationModel
    {
        public IEnumerable<ProiectDRXTransports.Models.TransportationModel> transportationModels { get; set; }
        public IEnumerable<ProiectDRXTransports.Models.LocationModel> locationModels { get; set; }
        public IEnumerable<ProiectDRXTransports.Models.DriverModel> driverModels { get; set; }
    }
}
