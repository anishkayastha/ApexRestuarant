using ApexRestaurant.Repository.Domain;

namespace ApexRestaurant.Repository.RMealDish {
    public class MealDishRepository : GenericRepository<MealDish>, IMealDishRepository {
        public MealDishRepository (RestaurantContext dbContext) {
            DbContext = dbContext;
        }
    }
}