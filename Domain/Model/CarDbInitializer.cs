using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Domain.Model
{
    public class CarDbInitializer : DropCreateDatabaseIfModelChanges<CarContext>
    {
        protected override void Seed(CarContext db)
        {
            //Card сardOne = new Card
            //{
            //    Address = "Minsk",
            //    DateOfBirth = "24.01.1987",
            //    Email = "imperaxel@gmail.com",
            //    FirstName = "Terehin",
            //    LastName = "Aleksander",
            //    Id = 1,
            //    Phone = "9484722"
            //};
            //Card сardTwo = new Card
            //{
            //    Address = "Minsk",
            //    DateOfBirth = "01.05.1991",
            //    Email = "valentina@gmail.com",
            //    FirstName = "Terehina",
            //    LastName = "Valentina",
            //    Id = 2,
            //    Phone = "7329426"
            //};
            //сardOne.Cars = new List<Car>();
            //сardTwo.Cars = new List<Car>();
            //сardOne.Cars.Add(new Car { Card = сardOne, Make = "Audi", Model = "Q7", Year = 2015, Vin = "rtjkkegtbw" });
            //сardTwo.Cars.Add(new Car { Card = сardTwo, Make = "BMW", Model = "X6", Year = 2017, Vin = "kfs;faegtbw" });
            //сardTwo.Cars.Add(new Car { Card = сardTwo, Make = "Infinity", Model = "FX-350", Year = 2016, Vin = "rtjmklhklhgmjttbw" });

            //db.Cards.AddRange(new List<Card> { сardOne, сardTwo });
            //db.SaveChanges();
            //Car c1 = new Car { Id = 1, Make = "Audi", Model = "Q3", Year = 2014, Vin = "TTEEEHJKG"};
            //Car c2 = new Car { Id = 2, Make = "BMW", Model = "X3", Year = 2014, Vin = "IIGJHGKBN" };
            //Car c3 = new Car { Id = 3, Make = "Mers", Model = "C600", Year = 2013, Vin = "SSSGWZFFGS" };
            //Car c4 = new Car { Id = 4, Make = "Opel", Model = "Vectra", Year = 2010, Vin = "BBBVCXDCDG" };

            //db.Cars.Add(c1);
            //db.Cars.Add(c2);
            //db.Cars.Add(c3);
            //db.Cars.Add(c4);

            //Order o1 = new Order { Id = 1, Date = DateTime.Parse("2001-03-01"), OrderAmount = 2200, OrderStatus = OrderStatus.Completed, Cars = new List<Car>() { c1, c2, c3 } };
            //Order o2 = new Order { Id = 1, Date = DateTime.Parse("2001-02-01"), OrderAmount = 2700, OrderStatus = OrderStatus.InProgress, Cars = new List<Car>() { c2, c3 } };
            //Order o3 = new Order { Id = 1, Date = DateTime.Parse("2001-07-01"), OrderAmount = 1400, OrderStatus = OrderStatus.Cancelled, Cars = new List<Car>() { c3, c4, c1 } };

            //db.Orders.Add(o1);
            //db.Orders.Add(o2);
            //db.Orders.Add(o3);
            //db.SaveChanges();
            base.Seed(db);
        }

        protected void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Car>()
                .HasMany(c => c.Orders)
                .WithMany(o => o.Cars)
                .Map(x => x.MapLeftKey("CarId")
                           .MapRightKey("OrderId")
                           .ToTable("CarOrder"));
        }
        
        
    }
}
