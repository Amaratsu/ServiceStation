using System.Collections.Generic;

namespace Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Vin { get; set; }
        public int? CardId { get; set; }
        public Card Card { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Car()
        {
            Orders = new List<Order>();
        }
    }
}