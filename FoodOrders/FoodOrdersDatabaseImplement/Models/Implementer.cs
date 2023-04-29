using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels;
using FoodOrdersDataModels.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FoodOrdersDatabaseImplement.Models
{
    [DataContract]
    public class Implementer : IImplementerModel
	{
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string ImplementerFIO { get; private set; } = string.Empty;
        [DataMember]
        public string Password { get; private set; } = string.Empty;
        [DataMember]
        public int WorkExperience { get; private set; }
        [DataMember]
        public int Qualification { get; private set; }

		[ForeignKey("ImplementerId")]
		public virtual List<Order> Orders { get; private set; } = new(); 

		public static Implementer? Create(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new()
			{
				Id = model.Id,
				Password = model.Password,
				Qualification = model.Qualification,
				ImplementerFIO = model.ImplementerFIO,
				WorkExperience = model.WorkExperience,
			};
		}

		public void Update(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			Password = model.Password;
			Qualification = model.Qualification;
			ImplementerFIO = model.ImplementerFIO;
			WorkExperience = model.WorkExperience;
		}

		public ImplementerViewModel GetViewModel => new()
		{
			Id = Id,
			Password = Password,
			Qualification = Qualification,
			ImplementerFIO = ImplementerFIO,
			WorkExperience = WorkExperience,
		};
	}
}
