using FoodOrdersBusinessLogic.BusinessLogics;
using FoodOrdersBusinessLogic.OfficePackage.Implements;
using FoodOrdersBusinessLogic.OfficePackage;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersDatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using FoodOrdersView;

namespace FoodOrdersView
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
            services.AddTransient<IComponentStorage, ComponentStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IDishStorage, DishStorage>();
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IShopStorage, ShopStorage>();

            services.AddTransient<IComponentLogic, ComponentLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IDishLogic, DishLogic>();
            services.AddTransient<IReportLogic, ReportLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IShopLogic, ShopLogic>();

            services.AddTransient<AbstractSaveToExcel, SaveToExcel>();
            services.AddTransient<AbstractSaveToWord, SaveToWord>();
            services.AddTransient<AbstractSaveToPdf, SaveToPdf>();

            services.AddTransient<FormMain>();
            services.AddTransient<FormClients>();
            services.AddTransient<FormComponent>();
            services.AddTransient<FormComponents>();
            services.AddTransient<FormCreateOrder>();
            services.AddTransient<FormDish>();
            services.AddTransient<FormDishComponents>();
            services.AddTransient<FormDishes>();
            services.AddTransient<FormReportDishComponents>();
            services.AddTransient<FormReportOrders>();
            services.AddTransient<FormShops>();
            services.AddTransient<FormShop>();
            services.AddTransient<FormDeliveryDishes>();
            services.AddTransient<FormSellDishes>();
            services.AddTransient<FormReportShopListDish>();
            services.AddTransient<FormReportOrdersGroupedByDate>();
        }
    }
}