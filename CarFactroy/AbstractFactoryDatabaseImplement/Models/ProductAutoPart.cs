using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AbstractFactoryDatabaseImplement.Models
{
    /// <summary>
    /// Сколько компонентов, требуется при изготовлении изделия
    /// </summary>
    public class ProductAutoPart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AutoPartId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual AutoPart AutoPart { get; set; }
        public virtual Product Product { get; set; }
    }
}
