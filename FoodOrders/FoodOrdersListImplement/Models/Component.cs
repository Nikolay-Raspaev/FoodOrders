using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System.Runtime.Serialization;

namespace FoodOrdersListImplement.Models
{
    //класс отвечает не только за хранение данных но также и за их изменение
    public class Component : IComponentModel
    {
        public int Id { get; private set; }
        public string ComponentName { get; private set; } = string.Empty;
        public double Cost { get; set; }

        //создаём из ComponentBindingModel Component
        public static Component? Create(ComponentBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Component()
            {
                Id = model.Id,
                ComponentName = model.ComponentName,
                Cost = model.Cost
            };
        }

        //изменённые данные из бизнес-логики передаём в поля Component
        public void Update(ComponentBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ComponentName = model.ComponentName;
            Cost = model.Cost;
        }

        //получение ComponentViewModel из Component
        public ComponentViewModel GetViewModel => new()
        {
            Id = Id,
            ComponentName = ComponentName,
            Cost = Cost
        };
    }
}