using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }//Id заказа
        public DateTime Date { get; set; }//дата
        public decimal OrderAmount { get; set; }//сумма заказа
        public OrderStatus OrderStatus { get; set; }//статус заказа
        public int? CardId { get; set; }
        public Card Card { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public Order()
        {
            Cars = new List<Car>();
        }
    }
}