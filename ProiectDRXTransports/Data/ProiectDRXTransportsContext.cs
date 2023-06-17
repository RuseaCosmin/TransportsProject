using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectDRXTransports.Models;

namespace ProiectDRXTransports.Data
{
    public class ProiectDRXTransportsContext : DbContext
    {
        public ProiectDRXTransportsContext (DbContextOptions<ProiectDRXTransportsContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectDRXTransports.Models.DriverModel> DriverModel { get; set; } = default!;

        public DbSet<ProiectDRXTransports.Models.LocationModel>? LocationModel { get; set; }

        public DbSet<ProiectDRXTransports.Models.TransportationModel>? TransportationModel { get; set; }

        public DbSet<ProiectDRXTransports.Models.GateModel>? GateModel { get; set; }

        public DbSet<ProiectDRXTransports.Models.TransportationScheduleModel>? TransportationScheduleModel { get; set; }

        

       
    }
}
