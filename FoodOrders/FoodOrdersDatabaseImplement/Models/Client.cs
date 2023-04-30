using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Runtime.Serialization;

namespace FoodOrdersDatabaseImplement.Models
{
    [DataContract]
    public class Client : IClientModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string ClientFIO { get; set; } = string.Empty;
        [DataMember]
        [Required]
        public string Email { get; set; } = string.Empty;
        [DataMember]
        [Required]
        public string Password { get; set; } = string.Empty;

        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { get; set; } = new();

		[ForeignKey("ClientId")]
		public virtual List<MessageInfo> Messages { get; set; } = new();

		public static Client? Create(ClientBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Client()
            {
                Id = model.Id,
                ClientFIO = model.ClientFIO,
                Email = model.Email,
                Password = model.Password
            };
        }

        //изменённые данные из бизнес-логики передаём в поля Component
        public void Update(ClientBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ClientFIO = model.ClientFIO;
            Password = model.Password;
            Email = model.Email;
        }

        //получение ComponentViewModel из Component
        public ClientViewModel GetViewModel => new()
        {
            Id = Id,
            ClientFIO = ClientFIO,
            Email = Email,
            Password = Password
        };
    }
}