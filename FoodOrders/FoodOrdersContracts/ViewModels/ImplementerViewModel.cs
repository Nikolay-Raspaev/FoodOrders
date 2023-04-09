using FoodOrdersDataModels.Models;
using System.ComponentModel;

namespace FoodOrdersContracts.ViewModels
{
    /// <summary>
    /// Исполнитель, выполняющий заказы
    /// </summary>
    public class ImplementerViewModel : IImplementerModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО исполнителя")]
        public string ImplementerFIO { get; set; } = string.Empty;

        [DisplayName("Пароль")]
        public string Password { get; set; } = string.Empty;

        [DisplayName("Стаж работы")]
        public int WorkExperience { get; set; }

        [DisplayName("Квалификация")]
        public int Qualification { get; set; }
    }
}