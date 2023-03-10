using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Basket.API.Entities
{
    [Table("BasketCartItems")]
    public class BasketCartItem
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }

        //[ForeignKey(nameof(BasketCart))]
        //        public BasketCart BasketCart { get; set; }

        //               public BasketCart? BasketCart { get; set; }
    }
}