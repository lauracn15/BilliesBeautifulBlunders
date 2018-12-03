using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Models
{
    public class ProductDetail
    {
        [Display(Name="ProductId")]
        public int ProductId { get; set; }

        public string Title { get; set; }
        public string Colors { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{ProductId}] {Title}";
    }
}
