using Microsoft.AspNetCore.Identity;

namespace ProiectDRXTransports.Models
{
    public class TransportationUser : IdentityUser  
    {
        public string Role { get; set; }
        public int LocationId { get; set; } = 0;
    }
}
