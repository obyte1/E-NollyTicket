using Microsoft.EntityFrameworkCore;
using NollyTickets.Ng.Models;

namespace NollyTickets.Ng.Data.Cart
{
    public class ShoppingCart
    {
        public ApplicationDbContext _context { get; set; }

        public string ShopppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context; 
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShopppingCartId ==
            ShopppingCartId).Include(n => n.Movie).ToList());
        }
        public double GetShoppingCartTotal() => _context.ShoppingCartItems.Where(n => n.ShopppingCartId == ShopppingCartId).Select(n =>
            n.Movie.Price * n.Amount).Sum();
           
        
    }
}
