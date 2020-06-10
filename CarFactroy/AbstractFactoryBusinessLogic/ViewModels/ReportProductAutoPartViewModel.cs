﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractFactoryBusinessLogic.ViewModels
{
    public class ReportProductAutoPartViewModel
    {
        public string AutoPartName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Products { get; set; }
    }
}
