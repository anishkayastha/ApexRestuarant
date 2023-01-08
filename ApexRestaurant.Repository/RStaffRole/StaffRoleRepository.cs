using ApexRestaurant.Repository.Domain;

namespace ApexRestaurant.Repository.RStaffRole {
    public class StaffRoleRepository : GenericRepository<StaffRole>, IStaffRoleRepository {
        public StaffRoleRepository (RestaurantContext dbContext) {
            DbContext = dbContext;
        }
    }
}