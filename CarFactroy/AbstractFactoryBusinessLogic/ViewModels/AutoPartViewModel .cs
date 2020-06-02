using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractFactoryBusinessLogic.ViewModels
{
    public class AutoPartViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название части")]
        public string AutoPartName { get; set; }
    }
}
