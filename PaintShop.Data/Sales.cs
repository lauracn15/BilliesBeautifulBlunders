using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Data
{
    public class Sales
    {
        [Key]
        public int SaleId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int DateOfPurchase { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
