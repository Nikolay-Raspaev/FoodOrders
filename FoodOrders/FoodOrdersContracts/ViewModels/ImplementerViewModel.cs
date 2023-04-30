using FoodOrdersContracts.Attributes;
using FoodOrdersDataModels.Models;
using System.ComponentModel;

namespace FoodOrdersContracts.ViewModels
{
    /// <summary>
    /// Исполнитель, выполняющий заказы
    /// </summary>
    public class ImplementerViewModel : IImplementerModel
    {
        [Column(visible: false)]
        public int Id { get; set; }

        [Column("ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ImplementerFIO { get; set; } = string.Empty;

        [Column("Пароль", width: 150)]
        public string Password { get; set; } = string.Empty;

        [Column("Стаж работы", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true)]
        public int WorkExperience { get; set; }

        [Column("Квалификация", gridViewAutoSize: GridViewAutoSize.AllCells, isUseAutoSize: true)]
        public int Qualification { get; set; }
    }
}