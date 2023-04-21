using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using Microsoft.Extensions.Logging;

namespace FoodOrdersBusinessLogic.BusinessLogics
{
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly ILogger _logger;
        private readonly IImplementerStorage _implementerStorage;
        public ImplementerLogic(ILogger<ImplementerLogic> logger, IImplementerStorage implementerStorage)
        {
            _logger = logger;
            _implementerStorage = implementerStorage;
        }

        public bool Create(ImplementerBindingModel model)
        {
            CheckModel(model);
            if (_implementerStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(ImplementerBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_implementerStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        public ImplementerViewModel? ReadElement(ImplementerSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. FIO:{FIO}.Id:{ Id}",
                model.ImplementerFIO, model.Id);
            var element = _implementerStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public List<ImplementerViewModel>? ReadList(ImplementerSearchModel? model)
        {
            _logger.LogInformation("ReadList. FIO:{FIO}.Id:{ Id} ", model?.ImplementerFIO, model?.Id);
            var list = (model == null) ? _implementerStorage.GetFullList() :
            _implementerStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public bool Update(ImplementerBindingModel model)
        {
            CheckModel(model);
            if (_implementerStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(ImplementerBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (model.WorkExperience < 0)
            {
                throw new ArgumentException("Опыт работы не должен быть отрицательным", nameof(model.WorkExperience));
            }
            if (model.Qualification < 0)
            {
                throw new ArgumentException("Квалификация не должна быть отрицательной", nameof(model.Qualification));
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new ArgumentNullException("Нет пароля исполнителя", nameof(model.ImplementerFIO));
            }
            if (string.IsNullOrEmpty(model.ImplementerFIO))
            {
                throw new ArgumentNullException("Нет фио исполнителя", nameof(model.ImplementerFIO));
            }
            _logger.LogInformation("Implementer. Id: {Id}, FIO: {FIO}", model.Id, model.ImplementerFIO);
            var element = _implementerStorage.GetElement(new ImplementerSearchModel
            {
                ImplementerFIO = model.ImplementerFIO,
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Исполнитель с таким фио уже есть");
            }
        }
    }
}
