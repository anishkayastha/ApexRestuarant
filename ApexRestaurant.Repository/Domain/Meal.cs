using System;
using System.ComponentModel.DataAnnotations;

namespace ApexRestaurant.Repository.Domain {
    public class Meal {
        [Key]
        public int MealId{ get; set; }
        public int StaffId { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date_of_Meal { get; set; }
        public string Cost_of_Meal { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}