using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
   public class ProductDetailDTo:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
