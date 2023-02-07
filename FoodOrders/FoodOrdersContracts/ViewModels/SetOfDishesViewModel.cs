using FoodOrdersDataModels.Models;
using System.ComponentModel;

namespace FoodOrdersContracts.ViewModels
{
    public class SetOfDishesViewModel : ISetOfDishesModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string SetOfDishesName { get; set; } = string.Empty;
        [DisplayName("Цена")]
        public double Price { get; set; }
        public Dictionary<int, (IDishModel, int)> SetOfDishesDishes {get; set;} = new();
    }
}
