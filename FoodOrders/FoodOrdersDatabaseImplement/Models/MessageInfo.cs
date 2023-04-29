using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FoodOrdersDatabaseImplement.Models
{
    [DataContract]
    public class MessageInfo : IMessageInfoModel
    {
		[Key]
        [DataMember]
        public string MessageId { get; private set; } = string.Empty;
        [DataMember]
        public int? ClientId { get; private set; }
        [DataMember]
        [Required]
		public string SenderName { get; private set; } = string.Empty;
        [DataMember]
        [Required]
		public DateTime DateDelivery { get; private set; }
        [DataMember]
        [Required]
		public string Subject { get; private set; } = string.Empty;
        [DataMember]
        [Required]
		public string Body { get; private set; } = string.Empty;
		public virtual Client? Client { get; set; }
		public static MessageInfo? Create(MessageInfoBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new MessageInfo()
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
