using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Domain.Enums;

namespace Domain.Entities
{
    public class Card
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
       
        public string DateOfBirth { get; set; }
       
        public string Address { get; set; }
        
        public string Phone { get; set; }
      
        public string Email { get; set; }


        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Card()
        {
            Cars = new List<Car>();
            Orders = new List<Order>();
        }  
    }
}