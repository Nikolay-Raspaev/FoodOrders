namespace FoodOrdersDataModels.Models
{
    public interface IMessageInfoModel
    {
        string MessageId { get; }

        int? ClientId { get; }

        string SenderName { get; }

        DateTime DateDelivery { get; }

        string Subject { get; }

        string Body { get; }
    }
}