using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Data
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        public string Title { get; set; }
        public string Size { get; set; }
        public string Colors { get; set; }
        public decimal Price { get; set; }
        public int AmountOfProducts { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc{ get; set; }

        public virtual Product Product { get; set; }
    }
}
