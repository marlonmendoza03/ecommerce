using Repository.RepositoryDTO;
using Services.Interfaces;
using Services.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Commands
{
    public partial class ProductCommandsServices : IServiceCommands
    {
        public void PlaceOrder(List<ShoppingCartData> productCommands)
        {
            var listOfOrders = productCommands.Select(x => new ShoppingCartItem()
            {
                ProductId = x.ProductId,
                ProductQuantity = x.ProductQuantity,
                Product = new ProductItemData()
                {
                    ProductId = x.ProductId,
                    ProductName = x.
                }
            });
        }
    }
}
