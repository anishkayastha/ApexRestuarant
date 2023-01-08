using System;
using System.ComponentModel.DataAnnotations;

namespace ApexRestaurant.Repository.Domain {
    public class Menu {
        [Key]
        public int Id { get; set; }
        public string Menu_Name { get; set; }
        public DateTime Available_Date_From { get; set; }
        public DateTime Available_Date_To { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}