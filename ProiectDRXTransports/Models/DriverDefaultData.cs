using Microsoft.EntityFrameworkCore;
using ProiectDRXTransports.Data;

namespace ProiectDRXTransports.Models
{
    public class DriverDefaultData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProiectDRXTransportsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProiectDRXTransportsContext>>()))
            {
                if (context.DriverModel.Any())
                {
                    return;   
                }

                context.DriverModel.AddRange(
                    new DriverModel
                    {
                        LastName = "Popescu",
                        FirstName = "Mihai",
                        PhoneNr = 747123123
                    },

                    new DriverModel
                    {
                        LastName = "Ionescu",
                        FirstName = "Andrei",
                        PhoneNr = 743987987
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
