﻿namespace FoodOrdersDataModels.Models
{
    public interface IClientModel : IId
    {
        string ClientFIO { get; }

        string Email { get; }

        string Password { get; }
    }
}