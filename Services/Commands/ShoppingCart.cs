using Repository.DataContext;
using Repository.Interfaces;
using Repository.RepositoryDTO;
using Services.Interfaces;
using Services.ServicesDTO;

namespace Services.Commands
{
    public partial class ProductCommandsServices : IServiceCommands
    {
        public void PlaceOrder(List<ShoppingCart> shoppingCart)
        {
            var listOfOrders = shoppingCart.Select(x => new ShoppingCart()
            {
                ProductId = x.ProductId,
                ProductQuantity = x.ProductQuantity,
                Cart = new ShoppingCartData()
                {
                    ProductId = x.Cart.ProductId,
                    ProductName = x.Cart.ProductName,
                    ProductPrice = x.Cart.ProductPrice,
                    ProductQuantity = x.Cart.ProductQuantity
                }
            }).ToList();
            _productCommands.Cart.AddRange(shoppingCart);
        }
    }
}
