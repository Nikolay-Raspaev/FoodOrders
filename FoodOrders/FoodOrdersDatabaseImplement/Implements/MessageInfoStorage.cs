﻿using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.SearchModels;
using FoodOrdersContracts.StoragesContracts;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDatabaseImplement.Models;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            using var context = new FoodOrdersDatabase();
            if (!string.IsNullOrEmpty(model.MessageId))
            {
                return context.Messages.FirstOrDefault(x => x.MessageId == model.MessageId)?.GetViewModel;
            }
            return null;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            if (!model.ClientId.HasValue)
            {
                return new();
            }
            using var context = new FoodOrdersDatabase();
            return context.Messages
                    .Where(x => x.ClientId == model.ClientId)
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new FoodOrdersDatabase();
            return context.Messages
                    .Select(x => x.GetViewModel)
                    .ToList();
        }

        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            var newMessage = MessageInfo.Create(model);
            if (newMessage == null)
            {
                return null;
            }
            using var context = new FoodOrdersDatabase();
            context.Messages.Add(newMessage);
            context.SaveChanges();
            return context.Messages
                                 .FirstOrDefault(x => x.MessageId == newMessage.MessageId)?.GetViewModel;
        }
    }
}