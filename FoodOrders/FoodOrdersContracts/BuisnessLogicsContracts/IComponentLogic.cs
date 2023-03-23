using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.BusinessLogicsContracts
{
    public interface IComponentLogic
    {
        //чтение листа, если модель есть то с фильтром, если модели нет то весь
        // знак вопроса так как модет вернуть null, а в качестве параметра, так как модель может не передаваться
        List<ComponentViewModel>? ReadList(ComponentSearchModel? model);
        ComponentViewModel? ReadElement(ComponentSearchModel model);
        bool Create(ComponentBindingModel model);
        bool Update(ComponentBindingModel model);
        bool Delete(ComponentBindingModel model);
    }
}
