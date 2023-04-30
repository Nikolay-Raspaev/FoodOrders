using FoodOrdersBusinessLogic.BusinessLogics;
using FoodOrdersBusinessLogic.OfficePackage.Implements;
using FoodOrdersBusinessLogic.OfficePackage;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersDatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using FoodOrdersBusinessLogic.MailWorker;
using FoodOrdersContracts.BindingModels;
using FoodOrdersDatabaseImplement;
using FoodOrdersContracts.DI;

namespace FoodOrdersView
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            InitDependency();

            try
            {
                var mailSender = DependencyManager.Instance.Resolve<AbstractMailWorker>();
                mailSender?.MailConfig(new MailConfigBindingModel
                {
                    MailLogin = System.Configuration.ConfigurationManager.AppSettings["MailLogin"] ?? string.Empty,
                    MailPassword = System.Configuration.ConfigurationManager.AppSettings["MailPassword"] ?? string.Empty,
                    SmtpClientHost = System.Configuration.ConfigurationManager.AppSettings["SmtpClientHost"] ?? string.Empty,
                    SmtpClientPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpClientPort"]),
                    PopHost = System.Configuration.ConfigurationManager.AppSettings["PopHost"] ?? string.Empty,
                    PopPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PopPort"])
                });

                // создаем таймер
                var timer = new System.Threading.Timer(new TimerCallback(MailCheck!), null, 0, 100000);
            }
            catch (Exception ex)
            {
                var logger = DependencyManager.Instance.Resolve<ILogger>();
                logger?.LogError(ex, "Ошибка работы с почтой");
            }

            Application.Run(DependencyManager.Instance.Resolve<FormMain>());
        }

        private static void InitDependency()
        {
            DependencyManager.InitDependency();

            DependencyManager.Instance.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
                option.AddNLog("nlog.config");
            });
            services.AddTransient<IComponentStorage, ComponentStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IDishStorage, DishStorage>();
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IImplementerStorage, ImplementerStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
            services.AddTransient<IShopStorage, ShopStorage>();

            DependencyManager.Instance.RegisterType<IComponentLogic, ComponentLogic>();
            DependencyManager.Instance.RegisterType<IOrderLogic, OrderLogic>();
            DependencyManager.Instance.RegisterType<IDishLogic, DishLogic>();
            DependencyManager.Instance.RegisterType<IReportLogic, ReportLogic>();
            DependencyManager.Instance.RegisterType<IClientLogic, ClientLogic>();
            DependencyManager.Instance.RegisterType<IImplementerLogic, ImplementerLogic>();
            DependencyManager.Instance.RegisterType<IMessageInfoLogic, MessageInfoLogic>();
            services.AddTransient<IComponentLogic, ComponentLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IDishLogic, DishLogic>();
            services.AddTransient<IReportLogic, ReportLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IImplementerLogic, ImplementerLogic>();   
            services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();

            services.AddTransient<IWorkProcess, WorkModeling>();
            services.AddSingleton<AbstractMailWorker, MailKitWorker>();
            services.AddTransient<IShopLogic, ShopLogic>();

            DependencyManager.Instance.RegisterType<AbstractSaveToExcel, SaveToExcel>();
            DependencyManager.Instance.RegisterType<AbstractSaveToWord, SaveToWord>();
            DependencyManager.Instance.RegisterType<AbstractSaveToPdf, SaveToPdf>();
            DependencyManager.Instance.RegisterType<IWorkProcess, WorkModeling>();
            DependencyManager.Instance.RegisterType<AbstractMailWorker, MailKitWorker>(true);
            DependencyManager.Instance.RegisterType<IBackUpLogic, BackUpLogic>();

            DependencyManager.Instance.RegisterType<FormMain>();
            DependencyManager.Instance.RegisterType<FormComponent>();
            DependencyManager.Instance.RegisterType<FormComponents>();
            DependencyManager.Instance.RegisterType<FormCreateOrder>();
            DependencyManager.Instance.RegisterType<FormDish>();
            DependencyManager.Instance.RegisterType<FormDishComponents>();
            DependencyManager.Instance.RegisterType<FormReportDishComponents>();
            DependencyManager.Instance.RegisterType<FormReportOrders>();
            DependencyManager.Instance.RegisterType<FormClients>();
        }
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
            services.AddTransient<FormViewImplementers>();
            services.AddTransient<FormImplementer>();
            services.AddTransient<FormMails>();
			services.AddTransient<FormReplyMail>();

		}

        private static void MailCheck(object obj) => DependencyManager.Instance.Resolve<AbstractMailWorker>()?.MailCheck();
    }
}