using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels.Models;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace FoodOrdersFileImplement.Models
{
    [DataContract]
    public class Client : IClientModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ClientFIO { get; set; } = string.Empty;
        [DataMember]
        public string Email { get; set; } = string.Empty;
        [DataMember]
        public string Password { get; set; } = string.Empty;

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

        public static Client? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Client()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ClientFIO = element.Element("ClientFIO")!.Value,
                Email = element.Element("Email")!.Value,
                Password = element.Element("Password")!.Value
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

        public XElement GetXElement => new(
            "Client",
            new XAttribute("Id", Id),
            new XElement("ClientFIO", ClientFIO),
            new XElement("Email", Email),
            new XElement("Password", Password)
        );
    }
}