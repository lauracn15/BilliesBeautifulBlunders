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
        public Guid OwnerId { get; set; }
        public int ProductId { get; set; }
        public int AmountOfProducts { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
