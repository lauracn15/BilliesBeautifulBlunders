using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Models
{
    public class SalesListItem
    {
        [Display(Name="Sales")]
        public int SalesId { get; set; }

        public int ProductId { get; set; }
        public int AmountOfProducts { get; set; }

 

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
