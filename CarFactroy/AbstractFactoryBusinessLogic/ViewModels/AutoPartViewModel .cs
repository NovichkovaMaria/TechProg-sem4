using System.ComponentModel;

namespace AbstractFactoryBusinessLogic.ViewModels
{
    public class AutoPartViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string AutoPartName { get; set; }
    }
}
