using FoodOrdersDataModels.Models;

namespace FoodOrdersContracts.BindingModels
{
    public class SetOfDishesBindingModel : ISetOfDishesModel
    {
        public int Id { get; set; }
        public string SetOfDishesName { get; set; } = string.Empty;
        public double Price { get; set; }
        public Dictionary<int, (IDishModel, int)> SetOfDishesDishes
        {
            get;
            set;
        } = new();
    }
}
