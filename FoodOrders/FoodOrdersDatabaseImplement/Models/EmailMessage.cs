using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdersDatabaseImplement.Models
{
	public class EmailMessage : IMessageInfoModel
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
		public static EmailMessage? Create(MessageInfoBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new EmailMessage()
			{
				MessageId = model.MessageId,
				ClientId = model.ClientId,
				SenderName = model.SenderName,
				Body = model.Body,
				Subject = model.Subject,
				DateDelivery = model.DateDelivery,
			};
		}
		public MessageInfoViewModel GetViewModel => new()
		{
			MessageId = MessageId,
			ClientId = ClientId,
			SenderName = SenderName,
			Body = Body,
			Subject = Subject,
			DateDelivery = DateDelivery,
		};

        public int Id => throw new NotImplementedException();
    }
}
