using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;

namespace FoodOrdersListImplement.Models
{
	// Update в этой сущности не нужен, поскольку в логике мы не изменяем никакие поля после создания письма
	public class MessageInfo : IMessageInfoModel
	{
		public string MessageId { get; private set; } = string.Empty;

		public int? ClientId { get; private set; }

		public string SenderName { get; private set; } = string.Empty;

		public DateTime DateDelivery { get; private set; } = DateTime.Now;

		public string Subject { get; private set; } = string.Empty;

		public string Body { get; private set; } = string.Empty;

		public static MessageInfo? Create(MessageInfoBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
				Body = model.Body,
				Subject = model.Subject,
				ClientId = model.ClientId,
				MessageId = model.MessageId,
				SenderName = model.SenderName,
				DateDelivery = model.DateDelivery,
			};
		}

		public MessageInfoViewModel GetViewModel => new()
		{
			Body = Body,
			Subject = Subject,
			ClientId = ClientId,
			MessageId = MessageId,
			SenderName = SenderName,
			DateDelivery = DateDelivery,
		};

        public int Id => throw new NotImplementedException();
    }

}
