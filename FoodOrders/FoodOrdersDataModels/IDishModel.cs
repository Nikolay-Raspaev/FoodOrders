
namespace FoodOrdersDataModels.Models
{
    public interface IDishModel : IId
    {
        string DishName { get; }
        double Cost { get; }
    }
}
