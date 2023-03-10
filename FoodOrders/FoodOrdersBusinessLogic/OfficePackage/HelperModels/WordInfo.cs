﻿using FoodOrdersContracts.ViewModels;

namespace FoodOrdersBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public List<ComponentViewModel> Components { get; set; } = new();
    }
}