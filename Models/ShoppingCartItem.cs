using System.ComponentModel.DataAnnotations;

namespace NollyTickets.Ng.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public string ShopppingCartId { get; set; }

    }
}
