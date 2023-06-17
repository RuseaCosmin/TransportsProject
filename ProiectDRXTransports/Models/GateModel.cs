using System.ComponentModel;

namespace ProiectDRXTransports.Models
{
    public class GateModel
    {
        [DisplayName("Gate ID")]

        public int Id { get; set; }
        [DisplayName("Location ID")]

        public int LocationModelId { get; set; }

        [DisplayName("Location Address")]
        public virtual LocationModel LocationModel { get; set; }
    }
}
