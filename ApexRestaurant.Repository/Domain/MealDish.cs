using System;
using System.ComponentModel.DataAnnotations;

namespace ApexRestaurant.Repository.Domain {
    public class MealDish {
        [Key]
        public int MealDishesId { get; set; }
        public int MealId { get; set; }
        public int MenuItemId { get; set; }
        public string Quantity { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}