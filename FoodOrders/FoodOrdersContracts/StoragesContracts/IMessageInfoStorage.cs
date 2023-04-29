using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.StoragesContracts
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();

        List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model);

        MessageInfoViewModel? GetElement(MessageInfoSearchModel model);

        MessageInfoViewModel? Insert(MessageInfoBindingModel model);

        MessageInfoViewModel? Update(MessageInfoBindingModel model);
    }
}