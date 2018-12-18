using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Models
{
    public class SalesDetail
    {
        
        public int SalesId { get; set; }
        public int CartId { get; set; }

        public string Title { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; } 
    }
}
