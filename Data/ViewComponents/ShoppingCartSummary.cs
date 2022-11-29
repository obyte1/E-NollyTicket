using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NollyTickets.Ng.Data.Cart;

namespace NollyTickets.Ng.Data.ViewComponents
{
    public class ShoppingCartSummary: ViewComponent
    {
        //Inject the shoppingCart
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        //The invoke method,that is required to call the  viewComponent
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}

