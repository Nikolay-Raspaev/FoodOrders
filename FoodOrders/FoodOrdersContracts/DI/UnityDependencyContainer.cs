using Microsoft.Extensions.Logging;
using System.ComponentModel;
using Unity;
using Unity.Lifetime;
using Unity.Microsoft.Logging;

namespace FoodOrdersContracts.DI
{
    public class UnityDependencyContainer : IDependencyContainer
    {
        private readonly IUnityContainer _container;

        public UnityDependencyContainer()
        {
            _container = new UnityContainer();
        }

        public void AddLogging(Action<ILoggingBuilder> configure)
        {
            var factory = LoggerFactory.Create(configure);
            _container.AddExtension(new LoggingExtension(factory));
        }

        public void RegisterType<T>(bool isSingle) where T : class
        {
            _container.RegisterType<T>(isSingle ? TypeLifetime.Singleton : TypeLifetime.Transient);

        }

        public T Resolve<T>()
        {
           return _container.Resolve<T>();
        }

        void IDependencyContainer.RegisterType<T, U>(bool isSingle)
        {
            _container.RegisterType<T, U>(isSingle ? TypeLifetime.Singleton : TypeLifetime.Transient);
        }
    }
}
