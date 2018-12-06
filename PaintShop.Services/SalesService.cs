using PaintShop.Data;
using PaintShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Services
{
    public class SalesService
    {
        private readonly Guid _userId;
        public SalesService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSales(SalesCreate model)
        {
            var entity =
                new Sales()
                {
                    OwnerId = _userId,
                    CartId = model.CartId,
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sales.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public SalesDetail GetSaleById(int salesId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sales
                    .Single(e => e.SalesId == salesId && e.OwnerId == _userId);
                return
                    new SalesDetail
                    {
                        CartId = entity.Cart.CartId,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }        





    }
}
