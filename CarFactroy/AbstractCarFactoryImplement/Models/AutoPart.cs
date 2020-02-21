using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractCarFactoryImplement.Models
{
    // Компонент, требуемый для изготовления изделия
    public class AutoPart
    {
        public int Id { get; set; }
        public string AutoPartName { get; set; }
    }
}
