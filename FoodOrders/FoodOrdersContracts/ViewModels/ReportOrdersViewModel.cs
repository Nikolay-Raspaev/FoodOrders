using FoodOrdersDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdersContracts.ViewModels
{
    public class ReportOrdersViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; }

        public string DishName { get; set; } = string.Empty;

        public double Sum { get; set; }

        public string OrderStatus { get; set; }
    }
}
