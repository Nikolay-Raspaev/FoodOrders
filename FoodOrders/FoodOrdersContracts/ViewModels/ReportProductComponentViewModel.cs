using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrdersContracts.ViewModels
{
    public class ReportDishComponentViewModel
    {
        public string ComponentName { get; set; } = string.Empty;

        public int TotalCount { get; set; }

        public List<(string Dish, int Count)> Dishes { get; set; } = new();
    }
}
