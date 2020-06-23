using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryBusinessLogic.BindingModels
{
    public class StorageBindingModel
    {
        public int Id { get; set; }
        public string StorageName { get; set; }
        public List<StorageAutoPartBindingModel> StorageAutoParts { get; set; }
    }
}