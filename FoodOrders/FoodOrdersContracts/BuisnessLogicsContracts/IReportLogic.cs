using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        List<ReportDishComponentViewModel> GetDishComponent();

        /// <summary>
        /// Получение списка блюда с указанием, в каких магазинах используются
        /// </summary>
        /// <returns></returns>
        List<ReportShopDishViewModel> GetShopDish();

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        /// <summary>
        /// Получение списка заказов, сгруппированных по дате
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersGroupedByDateViewModel> GetOrdersGroupedByDate();

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveDishesToWordFile(ReportBindingModel model);

        /// <summary>
        /// Сохранение магазинов в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveShopsToWordFile(ReportBindingModel model);

        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveDishComponentToExcelFile(ReportBindingModel model);

        /// <summary>
        /// Сохранение блюда с указаеним магазинов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveShopDishToExcelFile(ReportBindingModel model);

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersToPdfFile(ReportBindingModel model);

        /// <summary>
        /// Сохранение сгруппированных заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersGroupedByDateToPdfFile(ReportBindingModel model);
    }
}