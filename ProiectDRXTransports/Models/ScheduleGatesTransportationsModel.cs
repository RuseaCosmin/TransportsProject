namespace ProiectDRXTransports.Models
{
    public class ScheduleGatesTransportationsModel
    {
        public IEnumerable<ProiectDRXTransports.Models.TransportationModel> TransportationModels { get; set; }
        public IEnumerable<ProiectDRXTransports.Models.GateModel> GateModels { get; set; }
        public TransportationScheduleModel TransportationScheduleModel { get; set; }
    }
}
