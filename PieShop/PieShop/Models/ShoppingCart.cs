using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Models
{
    public class ShoppingCart
    {
        private readonly PieDbContext _pieDbContext;

        public ShoppingCart(PieDbContext pieDbContext)
        {
            _pieDbContext = pieDbContext;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<PieDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie, int amount)
        {
            var shoppingCartItem = _pieDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pie.Id == pie.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    Pie = pie,
                    ShoppingCartId = ShoppingCartId,
                    Amount = 1
                };

                _pieDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _pieDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem = _pieDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pie.Id == pie.Id && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _pieDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _pieDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _pieDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId).Include(s => s.Pie).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _pieDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId);

            _pieDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _pieDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _pieDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Select(p => p.Pie.Price * p.Amount).Sum();

            return total;
        }
    }
}
