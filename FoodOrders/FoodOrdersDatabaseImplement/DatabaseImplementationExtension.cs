using FoodOrdersContracts.DI;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersDatabaseImplement.Implements;

namespace FoodOrdersDatabaseImplement
{
    public class DatabaseImplementationExtension : IImplementationExtension
    {
        public int Priority => 2;

        public void RegisterServices()
        {
            DependencyManager.Instance.RegisterType<IClientStorage, ClientStorage>();
            DependencyManager.Instance.RegisterType<IComponentStorage, ComponentStorage>();
            DependencyManager.Instance.RegisterType<IImplementerStorage, ImplementerStorage>();
            DependencyManager.Instance.RegisterType<IMessageInfoStorage, MessageInfoStorage>();
            DependencyManager.Instance.RegisterType<IOrderStorage, OrderStorage>();
            DependencyManager.Instance.RegisterType<IDishStorage, DishStorage>();
            DependencyManager.Instance.RegisterType<IBackUpInfo, BackUpInfo>();
        }

    }
}
