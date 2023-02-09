using System;
using System.ComponentModel.DataAnnotations;

namespace ApexRestaurant.Mvc.Models {
    public class MenuItemViewModel {
        [Key]
        public int MenuItemId { get; set; }
        public int MenuId { get; set; }
        public string Menu_Items_Name { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}