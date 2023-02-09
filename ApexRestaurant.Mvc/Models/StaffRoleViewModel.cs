using System;
using System.ComponentModel.DataAnnotations;

namespace ApexRestaurant.Mvc.Models {
    public class StaffRoleViewModel {
        [Key]
        public int Staff_Roles_Id{ get; set; }
        public string Staff_Roles_Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}