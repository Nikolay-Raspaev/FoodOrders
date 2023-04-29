using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdersDatabaseImplement.Models
{
	public class MessageInfo : IMessageInfoModel
	{
		[Key]
		public string MessageId { get; private set; } = string.Empty;

		public int? ClientId { get; private set; }
		[Required]
		public string SenderName { get; private set; } = string.Empty;
		[Required]
		public DateTime DateDelivery { get; private set; }
		[Required]
		public string Subject { get; private set; } = string.Empty;
		[Required]
		public string Body { get; private set; } = string.Empty;
		public virtual Client? Client { get; set; }
        public bool HasRead { get; private set; }
        public string? Reply { get; private set; }
		public static MessageInfo? Create(MessageInfoBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new MessageInfo()
			{
                Body = model.Body,
                Reply = model.Reply,
                HasRead = model.HasRead,
                Subject = model.Subject,
                ClientId = model.ClientId,
				MessageId = model.MessageId,
				ClientId = model.ClientId,
				SenderName = model.SenderName,
				Body = model.Body,
				Subject = model.Subject,
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
			ClientId = ClientId,
			SenderName = SenderName,
			Body = Body,
			Subject = Subject,
			DateDelivery = DateDelivery,
		};
	}
}
