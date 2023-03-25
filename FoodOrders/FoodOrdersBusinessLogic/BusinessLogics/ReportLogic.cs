using FoodOrdersBusinessLogic.OfficePackage;
using FoodOrdersBusinessLogic.OfficePackage.HelperModels;
using FoodOrdersBusinessLogic.OfficePackage.HelperModels.Excel;
using FoodOrdersBusinessLogic.OfficePackage.HelperModels.Pdf;
using FoodOrdersBusinessLogic.OfficePackage.HelperModels.Word;
using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IComponentStorage _componentStorage;

        private readonly IDishStorage _dishStorage;

        private readonly IOrderStorage _orderStorage;

        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(IDishStorage dishStorage, IComponentStorage componentStorage, IOrderStorage orderStorage,
            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _dishStorage = dishStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;

            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        /// <summary>
        /// Получение списка компонент с указанием, в каких блюдах используются
        /// </summary>
        /// <returns></returns>
        public List<ReportDishComponentViewModel> GetDishComponent()
        {
            var components = _componentStorage.GetFullList();

            var dishes = _dishStorage.GetFullList();

            var list = new List<ReportDishComponentViewModel>();

            foreach (var dish in dishes)
            {
                var record = new ReportDishComponentViewModel
                {
                    DishName = dish.DishName,
                    Components = new List<(string, int)>(),
                    TotalCount = 0
                };
                foreach (var component in dish.DishComponents)
                {
                    record.Components.Add(new(component.Value.Item1.ComponentName, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }

                list.Add(record);
            }

            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderSearchModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
                    .Select(x => new ReportOrdersViewModel
                    {
                        Id = x.Id,
                        DateCreate = x.DateCreate,
                        DishName = x.DishName,
                        Sum = x.Sum,
                        OrderStatus = x.Status.ToString()
                    })
                    .ToList();
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список блюд",
                Dishes = _dishStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveDishComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                DishComponents = GetDishComponent()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom!.Value,
                DateTo = model.DateTo!.Value,
                Orders = GetOrders(model)
            });
        }
    }
}