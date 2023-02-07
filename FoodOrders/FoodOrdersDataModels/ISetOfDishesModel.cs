
namespace FoodOrdersDataModels.Models
{
    public interface ISetOfDishesModel : IId
    {
        string SetOfDishesName { get; }
        double Price { get; }
        Dictionary<int, (IDishModel, int)> SetOfDishesDishes { get; }
    }
}
