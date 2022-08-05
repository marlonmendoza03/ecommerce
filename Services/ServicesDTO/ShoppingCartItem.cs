using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesDTO
{
    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public ProductCommands Products { get; set; }
    }
}
