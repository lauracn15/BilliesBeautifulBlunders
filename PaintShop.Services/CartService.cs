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
        private List<ProductListItem> _productListItems = new List<ProductListItem>();
        private List<ProductListItem> _queryableList = new List<ProductListItem>();

        private readonly Guid _userId;

        public CartService(Guid userId)
        {
            _userId = userId;
        }
        private readonly int _cartId;
        public CartService(int cartId)
        {
            _cartId = cartId;
        }


        public bool CreateCart(CartCreate model)
        {
            var entity =
                new Cart()
                {
                    OwnerId = _userId,
                    CartId = model.CartId,
                    ProductId = model.ProductId,
                    AmountOfProducts = model.AmountOfProducts,
                    CreatedUtc = DateTimeOffset.Now
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
                            ProductId = e.ProductId,
                            CartId = e.CartId,
                            AmountOfProducts = e.AmountOfProducts,
                            CreatedUtc = e.CreatedUtc
                        }
                    );
                return query.ToArray();
            }
        }
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
                        AmountOfProducts = entity.AmountOfProducts,
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
                entity.AmountOfProducts = model.AmountOfProducts;
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
