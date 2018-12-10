using PaintShop.Data;
using PaintShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Services
{
    public class CartService
    {
        private readonly Guid _userId;

        public CartService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCart(CartCreate model)
        {
            var entity =
                new Cart()
                {
                    OwnerId = _userId,
                    ProductId = model.ProductId,
                    
               
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cart.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CartListItem> GetCart()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Cart
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new CartListItem
                        {
                            CartId = e.CartId,
                            ProductId = e.ProductId,
                            Price = e.Product.Price,
                            Title = e.Product.Title,
                            Colors = e.Product.Colors,
                            Size = e.Product.Size,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc,
                        }
                    );
                return query.ToArray();
            }
        }
        //public ProductListItem GetProductById(int id)
        //{
        //    using(var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Products
        //                .Single(e => e.ProductId == id && e.OwnerId == _userId);
        //        return
        //            new ProductListItem
        //            {
        //                ProductId = entity.ProductId,
        //                Title = entity.Title,
        //                Colors = entity.Colors,
        //                Size = entity.Size,
        //                Price = entity.Price,
        //            };
        //    }
        //}
        public CartDetail GetCartById(int cartId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cart
                    .Single(e => e.CartId == cartId && e.OwnerId == _userId);
                return
                    new CartDetail
                    {
                        CartId = entity.CartId,
                        ProductId = entity.ProductId,
                        Title = entity.Product.Title,
                        Size = entity.Product.Size,
                        Colors = entity.Product.Colors,
                        Price = entity.Product.Price,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateCart(CartEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cart
                    .Single(e => e.CartId == model.CartId && e.OwnerId == _userId);

                entity.CartId = model.CartId;
                entity.ProductId = model.ProductId;
             
            

                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCart(int cartId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Cart
                    .Single(e => e.CartId == cartId && e.OwnerId == _userId);

                ctx.Cart.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }







    }

}
