using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryBusinessLogic.BindingModels
{
    // Сколько компонента, требуется при изготовлении изделия 
   public class ProductAutoPartBindingModel
   {
        public int Id { get; set; } 

        public int ProductId { get; set; }

        public int AutoPartId { get; set; }

        public int Count { get; set; }
   }
}
