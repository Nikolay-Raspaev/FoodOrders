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

                // ������� ������
                var timer = new System.Threading.Timer(new TimerCallback(MailCheck!), null, 0, 100000);
            }
            catch (Exception ex)
            {
                var logger = DependencyManager.Instance.Resolve<ILogger>();
                logger?.LogError(ex, "������ ������ � ������");
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
            DependencyManager.Instance.RegisterType<IComponentStorage, ComponentStorage>();
            DependencyManager.Instance.RegisterType<IOrderStorage, OrderStorage>();
            DependencyManager.Instance.RegisterType<IDishStorage, DishStorage>();
            DependencyManager.Instance.RegisterType<IClientStorage, ClientStorage>();
            DependencyManager.Instance.RegisterType<IImplementerStorage, ImplementerStorage>();
            DependencyManager.Instance.RegisterType<IMessageInfoStorage, MessageInfoStorage>();
            DependencyManager.Instance.RegisterType<IShopStorage, ShopStorage>();

            DependencyManager.Instance.RegisterType<IComponentLogic, ComponentLogic>();
            DependencyManager.Instance.RegisterType<IOrderLogic, OrderLogic>();
            DependencyManager.Instance.RegisterType<IDishLogic, DishLogic>();
            DependencyManager.Instance.RegisterType<IReportLogic, ReportLogic>();
            DependencyManager.Instance.RegisterType<IClientLogic, ClientLogic>();
            DependencyManager.Instance.RegisterType<IImplementerLogic, ImplementerLogic>();
            DependencyManager.Instance.RegisterType<IMessageInfoLogic, MessageInfoLogic>();

            DependencyManager.Instance.RegisterType<IWorkProcess, WorkModeling>();
            DependencyManager.Instance.RegisterType<IShopLogic, ShopLogic>();

            DependencyManager.Instance.RegisterType<AbstractSaveToExcel, SaveToExcel>();
            DependencyManager.Instance.RegisterType<AbstractSaveToWord, SaveToWord>();
            DependencyManager.Instance.RegisterType<AbstractSaveToPdf, SaveToPdf>();
            DependencyManager.Instance.RegisterType<AbstractMailWorker, MailKitWorker>(true);
            DependencyManager.Instance.RegisterType<IBackUpLogic, BackUpLogic>();


            DependencyManager.Instance.RegisterType<FormMain>();
            DependencyManager.Instance.RegisterType<FormClients>();
            DependencyManager.Instance.RegisterType<FormComponent>();
            DependencyManager.Instance.RegisterType<FormComponents>();
            DependencyManager.Instance.RegisterType<FormCreateOrder>();
            DependencyManager.Instance.RegisterType<FormDish>();
            DependencyManager.Instance.RegisterType<FormDishComponents>();
            DependencyManager.Instance.RegisterType<FormDishes>();
            DependencyManager.Instance.RegisterType<FormReportDishComponents>();
            DependencyManager.Instance.RegisterType<FormReportOrders>();
            DependencyManager.Instance.RegisterType<FormShops>();
            DependencyManager.Instance.RegisterType<FormShop>();
            DependencyManager.Instance.RegisterType<FormDeliveryDishes>();
            DependencyManager.Instance.RegisterType<FormSellDishes>();
            DependencyManager.Instance.RegisterType<FormReportShopListDish>();
            DependencyManager.Instance.RegisterType<FormReportOrdersGroupedByDate>();
            DependencyManager.Instance.RegisterType<FormViewImplementers>();
            DependencyManager.Instance.RegisterType<FormImplementer>();
            DependencyManager.Instance.RegisterType<FormMails>();
			DependencyManager.Instance.RegisterType<FormReplyMail>();

		}

        private static void MailCheck(object obj) => DependencyManager.Instance.Resolve<AbstractMailWorker>()?.MailCheck();
    }
}