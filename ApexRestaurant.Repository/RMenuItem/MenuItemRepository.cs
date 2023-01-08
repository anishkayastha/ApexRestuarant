using ApexRestaurant.Repository.Domain;

namespace ApexRestaurant.Repository.RMenuItem {
    public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository {
        public MenuItemRepository (RestaurantContext dbContext) {
            DbContext = dbContext;
        }
    }
}