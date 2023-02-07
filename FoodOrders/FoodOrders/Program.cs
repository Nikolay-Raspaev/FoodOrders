using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.StoragesContracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using FoodOrdersView;
using FoodOrdersListImplement.Implements;
using FoodOrdersBusinessLogic.BusinessLogics;

namespace FoodOrders
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;
        public static ServiceProvider? ServiceProvider => _serviceProvider;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });
            services.AddTransient<IDishestorage, Dishestorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<ISetOfDishestorage, SetOfDishestorage>();
            services.AddTransient<IDishLogic, DishLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<ISetOfDishesLogic, SetOfDishesLogic>();
            services.AddTransient<FormMain>();
            services.AddTransient<FormDish>();
            services.AddTransient<FormDishes>();
            services.AddTransient<FormCreateOrder>();
            services.AddTransient<FormSetOfDishes>();
            services.AddTransient<FormSetOfDishesDishes>();
            services.AddTransient<FormListSetOfDishes>();
        }
    }
}