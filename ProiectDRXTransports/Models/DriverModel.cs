using System.ComponentModel;

namespace ProiectDRXTransports.Models
{
    public class DriverModel
    {
        [DisplayName("Driver ID")]
        public int Id { get; set; }
        [DisplayName("Driver Last Name")]

        public string LastName { get; set; }
        [DisplayName("Driver First Name")]
        public string FirstName { get; set; }
        [DisplayName("Phone Number")]
        public int PhoneNr { get; set; }

        public override string? ToString()
        {
            return Id.ToString();
        }
    }
}
