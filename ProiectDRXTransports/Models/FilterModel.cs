using System.ComponentModel;

namespace ProiectDRXTransports.Models
{
    public class FilterModel
    {
        [DisplayName("Location ID")]
        public int LocationId { get; set; }
        [DisplayName("Gate ID")]
        public int GateId   { get; set; }
    }
}
