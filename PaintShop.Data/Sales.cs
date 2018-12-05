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
        public int SalesId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }



    }
}
