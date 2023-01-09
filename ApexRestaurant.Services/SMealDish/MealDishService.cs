using ApexRestaurant.Repository.Domain;
using ApexRestaurant.Repository.RMealDish;

namespace ApexRestaurant.Services.SMealDish {
    public class MealDishService : GenericService<MealDish>, IMealDishService {
        public MealDishService (IMealDishRepository mealDishRepository) : base (mealDishRepository)
        {
        }
    }
}