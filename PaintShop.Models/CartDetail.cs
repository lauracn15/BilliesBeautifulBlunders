using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Models
{
    public class CartDetail
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }

        [Required]
        public int AmountOfProducts { get; set; }


        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public decimal Price { get; set; }
        public string Colors { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }

        public override string ToString() => $"[{CartId}] {ProductId}";
        
    }
}
