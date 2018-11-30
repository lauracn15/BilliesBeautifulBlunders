using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Models
{
    public class ProductCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Colors { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public decimal Price { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
