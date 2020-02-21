using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractFactoryBusinessLogic.ViewModels
{
    public class ProductAutoPartViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int AutoPartId { get; set; }

        [DisplayName("Компонент")]
        public string AutoPartName { get; set; }

        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
