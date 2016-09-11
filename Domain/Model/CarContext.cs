using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Model
{
    public class CarContext : DbContext
    {
        
        public CarContext(): base("CarContext")
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Order> Orders { get; set; }

        
    }

    
}
