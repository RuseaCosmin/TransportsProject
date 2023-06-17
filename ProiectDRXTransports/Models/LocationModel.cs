using System.ComponentModel;

namespace ProiectDRXTransports.Models
{
    public class LocationModel
    {
        [DisplayName("Location ID")]
        public int Id { get; set; }
        [DisplayName("Address")]

        public string Adress { get; set; }

        public override string? ToString()
        {
            return Id.ToString();
        }
    }
}
