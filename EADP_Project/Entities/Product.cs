using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EADP_Project_Education.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string EduLevel { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
    }
}