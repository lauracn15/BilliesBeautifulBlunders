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

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int AmountOfProducts { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc{ get; set; }

        public virtual Product Product { get; set; }
    }
}
