﻿using PaintShop.Data;
using PaintShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintShop.Services
{
    public class ProductService
    {
        private readonly Guid _userId;
        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Colors = model.Colors,
                    Size = model.Size,
                    Price = model.Price,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new ProductListItem
                        {
                            ProductId = e.ProductId,
                            Title = e.Title,
                            Price = e.Price,
                            Colors = e.Colors,
                            Size = e.Size,
                            CreatedUtc = e.CreatedUtc
                        }
                  );
                return query.ToArray();
            }

        }

        public ProductDetail GetProductById(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.ProductId == productId && e.OwnerId == _userId);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        Title = entity.Title,
                        Colors = entity.Colors,
                        Size = entity.Size,
                        Price = entity.Price,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,

                    };
                
            }
        }
    }
}
