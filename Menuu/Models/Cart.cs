﻿using Menuu.Context;
using Microsoft.EntityFrameworkCore;

namespace Menuu.Models
{
    public class Cart
    {
        private readonly AppDbContext _context;
        public Cart(AppDbContext context)
        {
            _context = context;
        }
        public string CartId { get; set; }
        public List<CartItem> CartItems { get; set; }
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();


            session.SetString("CartId", cartId);

            return new Cart(context)
            {
                CartId = cartId
            };
        }

        public void AddToCart(Snack snack)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                s => s.Snack.SnackId == snack.SnackId &&
                s.CartId == CartId);
            
            if(cartItem == null)
            {
                cartItem = new CartItem
                {
                    CartId = CartId,
                    Snack = snack,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public int RemoveFromCart(Snack snack)
        {
            var cartItem = _context.CartItems.SingleOrDefault(
                s => s.Snack.SnackId == snack.SnackId &&
                s.CartId == CartId);

            var localQuantity = 0;

            if(cartItem != null)
            {
                if(cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    localQuantity = cartItem.Quantity;
                }
                else
                {
                    _context.CartItems.Remove(cartItem);
                }
            }
            _context.SaveChanges();
            return localQuantity;
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems ??
                (CartItems =
                 _context.CartItems
                 .Where(c => c.CartId == CartId)
                 .Include(s => s.Snack)
                 .ToList());
                
        }

        public void CleanCart()
        {
            var cartItens = _context.CartItems
                           .Where(cart => cart.CartId == CartId);

            _context.CartItems.RemoveRange(cartItens);
            _context.SaveChanges();
        }

        public decimal GetCartTotal()
        {
            var total = _context.CartItems
                        .Where(c => c.CartId == CartId)
                        .Select(c => c.Snack.Price * c.Quantity).Sum();
            return total;
        }
    }
}
