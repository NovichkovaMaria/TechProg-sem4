using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractFactoryBusinessLogic.ViewModels
{
    public class StorageAutoPartViewModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int AutoPartId { get; set; }
        [DisplayName("Название части")]
        public string AutoPartName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}