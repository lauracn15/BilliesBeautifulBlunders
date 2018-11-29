using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Data
{
   public class Product
    {   [Key]
        public int ProductId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Colors { get; set; }

        [Required]
        public string Dimensions { get; set; }

        [Required]
        public DateTimeOffset PurchaseDate { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
