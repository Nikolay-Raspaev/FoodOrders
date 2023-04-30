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

        public int Id => throw new NotImplementedException();
    }
}
