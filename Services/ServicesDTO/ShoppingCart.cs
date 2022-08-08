using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesDTO
{
    public class ShoppingCartService
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public ShoppingCartServiceData Cart { get; set; }
    }

    public class ShoppingCartServiceData
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
