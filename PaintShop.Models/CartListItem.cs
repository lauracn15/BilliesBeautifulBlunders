using PaintShop.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Models
{
    public class CartListItem
    {
        
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int AmountOfProducts { get; set; }

        public string Colors { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

        public virtual Product Product { get; set; }
        public string Title { get; set; }
        

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
