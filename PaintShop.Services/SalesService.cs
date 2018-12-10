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
                            CartId = e.Cart.CartId, 
                            Price = e.Cart.Price,
                            Title = e.Cart.Title,
                          
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
