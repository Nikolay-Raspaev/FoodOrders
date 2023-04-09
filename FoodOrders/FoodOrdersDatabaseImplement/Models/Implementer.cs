using FoodOrdersContracts.BindingModels;
using FoodOrdersContracts.ViewModels;
using FoodOrdersDataModels;
using FoodOrdersDataModels.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrdersDatabaseImplement.Models
{
	public class Implementer : IImplementerModel
	{
		public int Id { get; private set; }

		public string ImplementerFIO { get; private set; } = string.Empty;

		public string Password { get; private set; } = string.Empty;

		public int WorkExperience { get; private set; }

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
