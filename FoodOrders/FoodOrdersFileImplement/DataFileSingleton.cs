﻿using FoodOrdersFileImplement.Models;
using System.Xml.Linq;
namespace FoodOrdersFileImplement
{
    public class DataFileSingleton
    {
        private static DataFileSingleton? instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string DishFileName = "Dish.xml";
        private readonly string ClientFileName = "Clients.xml";
        private readonly string ShopFileName = "Shop.xml";
        public List<Component> Components { get; private set; }
        public List<Order> Orders { get; private set; }
        public List<Dish> Dishes { get; private set; }
        public List<Shop> Shops { get; private set; }
        public List<Client> Clients { get; private set; }
        
        public static DataFileSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataFileSingleton();
            }
            return instance;
        }
        public void SaveComponents() => SaveData(Components, ComponentFileName, "Components", x => x.GetXElement);
        public void SaveDishes() => SaveData(Dishes, DishFileName, "Dishes", x => x.GetXElement);
        public void SaveOrders() => SaveData(Orders, OrderFileName, "Orders", x => x.GetXElement);
        public void SaveShops() => SaveData(Shops, ShopFileName, "Shops", x => x.GetXElement);
        public void SaveClients() => SaveData(Clients, ClientFileName, "Clients", x => x.GetXElement);
        private DataFileSingleton()
        {
            Components = LoadData(ComponentFileName, "Component", x => Component.Create(x)!)!;
            Dishes = LoadData(DishFileName, "Dish", x => Dish.Create(x)!)!;
            Orders = LoadData(OrderFileName, "Order", x => Order.Create(x)!)!;
            Clients = LoadData(ClientFileName, "Client", x => Client.Create(x)!)!;
            Shops = LoadData(ShopFileName, "Shop", x => Shop.Create(x)!)!;
        }
        private static List<T>? LoadData<T>(string filename, string xmlNodeName, Func<XElement, T> selectFunction)
        {
            if (File.Exists(filename))
            {
                return XDocument.Load(filename)?.Root?.Elements(xmlNodeName)?.Select(selectFunction)?.ToList();
            }
            return new List<T>();
        }
        private static void SaveData<T>(List<T> data, string filename, string xmlNodeName, Func<T, XElement> selectFunction)
        {
            if (data != null)
            {
                new XDocument(new XElement(xmlNodeName, data.Select(selectFunction).ToArray())).Save(filename);
            }
        }
    }
}

