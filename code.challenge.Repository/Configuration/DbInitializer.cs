using code.challenge.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.challenge.Repository.Configuration
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new MemoryDbContext(serviceProvider.GetRequiredService<DbContextOptions<MemoryDbContext>>()))
            {
                if (_context.Cars.Any())
                {
                    return;
                }

                _context.Cars.AddRange(
                    new Car { Id = 1, Make = "Audi", Model = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
                    new Car { Id = 2, Make = "Tesla", Model = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
                    new Car { Id = 3, Make = "Porche", Model = "911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
                    new Car { Id = 4, Make = "Mercedes-Benz", Model = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
                    new Car { Id = 5, Make = "BMW", Model = "X6 M", Year = 2018, Doors = 5, Color = "Silver", Price = 62995 }
                 );

                _context.SaveChanges();
            }
        }
    }
}
