using System.ComponentModel;

namespace ProiectDRXTransports.Models
{
    public class TransportationScheduleModel
    {
        public int Id { get; set; }
        [DisplayName("Delivery Time")]
        public TimeSpan DeliveryTime { get; set; }
        [DisplayName("Gate ID")]
        public int GateModelId { get; set; }
        [DisplayName("Gate")]
        public virtual GateModel GateModel { get; set; }
        [DisplayName("Transport ID")]
        public int TransportationModelId { get; set; }
        [DisplayName("Transport")]
        public virtual TransportationModel TransportationModel { get; set; }


    }
}
