using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.BusinessLogicsContracts;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using Microsoft.Extensions.Logging;

namespace FoodOrdersBusinessLogic.BusinessLogics
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly ILogger _logger;
        private readonly IMessageInfoStorage _messageInfoStorage;
        public MessageInfoLogic(ILogger<MessageInfoLogic> logger, IMessageInfoStorage messageInfoStorage)
        {
            _logger = logger;
            _messageInfoStorage = messageInfoStorage;
        }

        public bool Create(MessageInfoBindingModel model)
        {
            if (_messageInfoStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public MessageInfoViewModel? ReadElement(MessageInfoSearchModel model)
        {
            var res = _messageInfoStorage.GetElement(model);
            if (res == null)
            {
                _logger.LogWarning("Read element operation failed");
                return null;
            }
            return res;
        }

        public bool Update(MessageInfoBindingModel model)
        {
            if (_messageInfoStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model)
        {
            _logger.LogInformation("ReadList. ClientId:{ClientId}", model?.ClientId);
            var list = model == null ? _messageInfoStorage.GetFullList() : _messageInfoStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
    }
}