﻿using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace FoodOrdersFileImplement.Models
{
	// Update в этой сущности не нужен, поскольку в логике мы не изменяем никакие поля после создания письма
	[DataContract]
	public class MessageInfo : IMessageInfoModel
    {
        [DataMember]
        public string MessageId { get; private set; } = string.Empty;

        [DataMember]
        public int? ClientId { get; private set; }

        [DataMember]
        public string SenderName { get; private set; } = string.Empty;

        [DataMember]
        public DateTime DateDelivery { get; private set; } = DateTime.Now;

        [DataMember]
        public string Subject { get; private set; } = string.Empty;

        [DataMember]
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

		public static MessageInfo? Create(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return new()
			{
				Body = element.Attribute("Body")!.Value,
				Subject = element.Attribute("Subject")!.Value,
				ClientId = Convert.ToInt32(element.Attribute("ClientId")!.Value),
				MessageId = element.Attribute("MessageId")!.Value,
				SenderName = element.Attribute("SenderName")!.Value,
				DateDelivery = Convert.ToDateTime(element.Attribute("DateDelivery")!.Value),
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

		public XElement GetXElement => new("MessageInfo",
			new XAttribute("Body", Body),
			new XAttribute("Subject", Subject),
			new XAttribute("ClientId", ClientId),
			new XAttribute("MessageId", MessageId),
			new XAttribute("SenderName", SenderName),
			new XAttribute("DateDelivery", DateDelivery)
			);

        public int Id => throw new NotImplementedException();
    }

}
