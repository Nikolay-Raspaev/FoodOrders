
namespace FoodOrdersDataModels.Models
{
    public interface IDishModel : IId
    {
        //в словаре первый int это id, то есть по id компонента найдём сам компонент
        //дальше идёт кортеж в котором находиться уже копмонент и то сколько таких компонентов в данном блюде
        string DishName { get; }
        double Price { get; }
        Dictionary<int, (IComponentModel, int)> DishComponents { get; }
    }
}
