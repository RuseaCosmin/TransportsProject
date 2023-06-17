namespace ProiectDRXTransports.Models
{
    public class TransportationLocationDriverModel
    {
        public TransportationModel transportationModel { get; set; }
        public IEnumerable<ProiectDRXTransports.Models.LocationModel> locationModels { get; set; }
        public IEnumerable<ProiectDRXTransports.Models.DriverModel> driverModels { get; set; }
    }
}
