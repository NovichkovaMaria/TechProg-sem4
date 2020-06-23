using AbstractFactoryListImplement.Models;
using System.Collections.Generic;

namespace AbstractFactoryListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<AutoPart> AutoParts { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductAutoPart> ProductAutoParts { get; set; }
        public List<Storage> Storages { get; set; }
        public List<StorageAutoPart> StorageAutoParts { get; set; }
        private DataListSingleton()
        {
            AutoParts = new List<AutoPart>();
            Orders = new List<Order>();
            Products = new List<Product>();
            ProductAutoParts = new List<ProductAutoPart>();
            Storages = new List<Storage>();
            StorageAutoParts = new List<StorageAutoPart>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}