using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersFileImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            throw new NotImplementedException();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            throw new NotImplementedException();
        }

        public MessageInfoViewModel? Update(MessageInfoBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}