using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.ViewModels;

namespace FoodOrdersContracts.BusinessLogicsContracts
{
    public interface IMessageInfoLogic
    {
		List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model);

		bool Create(MessageInfoBindingModel model);

		bool Update(MessageInfoBindingModel model);

		MessageInfoViewModel? ReadElement(MessageInfoSearchModel model);
	}
}