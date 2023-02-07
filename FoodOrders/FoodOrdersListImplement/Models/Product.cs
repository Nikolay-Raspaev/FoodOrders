using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;

namespace FoodOrdersListImplement.Models
{
    public class SetOfDishes : ISetOfDishesModel
    {
        public int Id { get; private set; }
        public string SetOfDishesName { get; private set; } = string.Empty;
        public double Price { get; private set; }
        public Dictionary<int, (IDishModel, int)> SetOfDishesDishes
        {
            get;
            private set;
        } = new Dictionary<int, (IDishModel, int)>();
        public static SetOfDishes? Create(SetOfDishesBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new SetOfDishes()
            {
                Id = model.Id,
                SetOfDishesName = model.SetOfDishesName,
                Price = model.Price,
                SetOfDishesDishes = model.SetOfDishesDishes
            };
        }
        public void Update(SetOfDishesBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            SetOfDishesName = model.SetOfDishesName;
            Price = model.Price;
            SetOfDishesDishes = model.SetOfDishesDishes;
        }
        public SetOfDishesViewModel GetViewModel => new()
        {
            Id = Id,
            SetOfDishesName = SetOfDishesName,
            Price = Price,
            SetOfDishesDishes = SetOfDishesDishes
        };
    }
}