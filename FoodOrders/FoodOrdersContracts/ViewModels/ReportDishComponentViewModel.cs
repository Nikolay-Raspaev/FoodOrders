using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdersContracts.ViewModels
{
    public class ReportDishComponentViewModel
    {
        public string DishName { get; set; } = string.Empty;

        public int TotalCount { get; set; }

        public List<(string Component, int Count)> Components { get; set; } = new();
    }
}
