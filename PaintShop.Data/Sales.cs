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
        public int CartId { get; set; }
       

        [Required]
        public Guid OwnerId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
