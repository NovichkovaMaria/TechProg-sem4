using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryBusinessLogic.BindingModels
{
   public class StorageAutoPartBindingModel
   {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int AutoPartId { get; set; }
        public int Count { get; set; }
   }
}