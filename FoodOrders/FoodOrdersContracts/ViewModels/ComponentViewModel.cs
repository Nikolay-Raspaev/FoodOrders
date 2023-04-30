using FoodOrdersContracts.Attributes;
using FoodOrdersDataModels.Models;
using System.ComponentModel;
namespace FoodOrdersContracts.ViewModels
{
    public class ComponentViewModel : IComponentModel
    {
        [Column(visible: false)]
        public int Id { get; set; }

        [Column("Название компонента", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ComponentName { get; set; } = string.Empty;

        [Column("Цена", width: 80)]
        public double Cost { get; set; }
    }
}
