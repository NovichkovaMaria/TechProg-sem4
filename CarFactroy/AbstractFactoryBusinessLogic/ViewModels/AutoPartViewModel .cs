using AbstractFactoryBusinessLogic.Attributes;
using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractFactoryBusinessLogic.ViewModels
{
    public class AutoPartViewModel : BaseViewModel
    {
        [Column(title: "Часть", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string AutoPartName { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "AutoPartName"
        };
    }
}