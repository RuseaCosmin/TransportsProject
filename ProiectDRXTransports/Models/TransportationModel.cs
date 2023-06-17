using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProiectDRXTransports.Models
{
    public class TransportationModel
    {
        public int Id { get; set; }
        [DisplayName("Status")]
        public string StatusTransport { get; set; }
        [DisplayName("Sent Date")]
        [DataType(DataType.Date)]
        public DateTime SentDate { get; set; }
        [DisplayName("Arrival Date")]

        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }
        [DisplayName("Driver ID")]

        public int DriverModelId { get; set; }

        public virtual DriverModel DriverModel { get; set; }
        [DisplayName("Location ID")]

        public int LocationModelId { get; set; }

        public virtual LocationModel LocationModel { get; set; }
    }
}
