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

        private readonly IShopStorage _shopStorage;

        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(IDishStorage dishStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, IShopStorage shopStorage,
        AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _dishStorage = dishStorage;
            _orderStorage = orderStorage;
            _shopStorage = shopStorage;

            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportDishComponentViewModel> GetDishComponent()
        {
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
        /// Получение списка блюда с указанием, в каких магазинах используются
        /// </summary>
        /// <returns></returns>
        public List<ReportShopDishViewModel> GetShopDish()
        {
            var shops = _shopStorage.GetFullList();

            var list = new List<ReportShopDishViewModel>();

            foreach (var shop in shops)
            {
                var record = new ReportShopDishViewModel
                {
                    ShopName = shop.ShopName,
                    ListDish = new(),
                    TotalCount = 0
                };
                foreach (var sushi in shop.ShopDishes)
                {
                    record.ListDish.Add(new(sushi.Value.Item1.DishName, sushi.Value.Item2));
                    record.TotalCount += sushi.Value.Item2;
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
        /// 
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
        /// Получение списка заказов, сгруппированных по дате
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersGroupedByDateViewModel> GetOrdersGroupedByDate()
        {
            return _orderStorage.GetFullList()
                .GroupBy(x => x.DateCreate.Date)
                .Select(x => new ReportOrdersGroupedByDateViewModel
                {
                    DateCreate = x.Key,
                    Count = x.Count(),
                    Sum = x.Sum(x => x.Sum)
                })
                .ToList();
        }

        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveDishesToWordFile(ReportBindingModel model)
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
        /// Сохранение магазинов в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveShopsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateShopsDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список магазинов",
                Shops = _shopStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение блюда с указаеним магазина в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveShopDishToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateShopReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список магазинов",
                ShopListDish = GetShopDish()
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

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersGroupedByDateToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateOrdersGroupedByDateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                OrdersGroupedByDate = GetOrdersGroupedByDate()
            });
        }
    }
}