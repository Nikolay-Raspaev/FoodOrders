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

        public bool HasRead { get; private set; }

        public string? Reply { get; private set; }
        public static MessageInfo? Create(MessageInfoBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
                Body = model.Body,
                Reply = model.Reply,
                HasRead = model.HasRead,
                Subject = model.Subject,
                ClientId = model.ClientId,
                MessageId = model.MessageId,
                SenderName = model.SenderName,
                DateDelivery = model.DateDelivery,
            };
		}

        public void Update(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            Reply = model.Reply;
            HasRead = model.HasRead;
        }

        public MessageInfoViewModel GetViewModel => new()
        {
            Body = Body,
            Reply = Reply,
            HasRead = HasRead,
            Subject = Subject,
            ClientId = ClientId,
            MessageId = MessageId,
            SenderName = SenderName,
            DateDelivery = DateDelivery,
        };
    }

}
