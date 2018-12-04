using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Models
{
    public class CartEdit
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int AmountOfProducts { get; set; }
    }
}
