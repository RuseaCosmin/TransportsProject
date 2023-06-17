using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectDRXTransports.Models;

namespace ProiectDRXTransports.Data
{
    public class ApplicationDbContext : IdentityDbContext<TransportationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}