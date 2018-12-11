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
                    CartId = model.CartId
                };

            using (var ctx = new ApplicationDbContext())
            {
                entity.ProductId = ctx.Cart.FirstOrDefault(c => c.CartId == entity.CartId).ProductId;

                ctx.Sales.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SalesListItem> GetSales()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sales
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                        new SalesListItem
                        {
                            SalesId = e.SalesId,
                            CartId = e.CartId,
                            Price = e.Cart.Product.Price,
                            Title = e.Cart.Product.Title,
                            Colors = e.Cart.Product.Colors,
                            Size = e.Cart.Product.Size,
                        }
                    );
                return query.ToArray();
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

                    };
            }
        }
        public bool UpdateSales(SalesEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sales
                    .Single(e => e.SalesId == model.SalesId && e.OwnerId == _userId);

                entity.CartId = model.CartId;
                entity.SalesId = model.SalesId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSales(int salesId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sales
                    .Single(e => e.SalesId == salesId && e.OwnerId == _userId);

                ctx.Sales.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



    }
}
