using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal OrderAmount { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int? CardId { get; set; }
        public Card Card { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public Order()
        {
            Cars = new List<Car>();
        }
    }
}