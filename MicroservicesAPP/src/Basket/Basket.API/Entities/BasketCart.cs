using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    [Table("BasketCarts")]
    public class BasketCart
    {
        //        public int Id { get; set; }
        [Key]
        [Required]
        public string UserName { get; set; }

        [ForeignKey(nameof(BasketCart))]
        public ICollection<BasketCartItem> BasketCartItems { get; set; } = new List<BasketCartItem>();

        public BasketCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in BasketCartItems)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
        }

        //       public ICollection<BasketCartItem> basketCartItems { get; set; }
    }
}