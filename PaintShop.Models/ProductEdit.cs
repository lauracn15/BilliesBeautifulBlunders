using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Models
{
    public class ProductEdit
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public string Colors { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }
}
