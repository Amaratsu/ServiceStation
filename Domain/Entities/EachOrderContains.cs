using System;
using Domain.Enums;

namespace Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }//Id заказа
        public DateTime Date { get; set; }//дата
        public decimal OrderAmount { get; set; }//сумма заказа
        public OrderStatus OrderStatus { get; set; }//статус заказа
    }
}