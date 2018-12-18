using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Models
{
    public class SalesCreate
    {
        public int CartId { get; set; }

        public int ProductId { get; set; }
        public int SalesId { get; set; }
    }
}
