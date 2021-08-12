using CarRentalWeb.BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalWeb.Data
{
    public class CarRentalDBContext : DbContext
    {
        public CarRentalDBContext(DbContextOptions<CarRentalDBContext> options)
            : base(options)
        {
        }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<RentDetail> RentDetails { get; set; }
    }
}
