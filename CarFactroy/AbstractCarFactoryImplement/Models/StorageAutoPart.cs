using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryListImplement.Models
{
    public class StorageAutoPart
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int AutoPartId { get; set; }
        public int Count { get; set; }
    }
}