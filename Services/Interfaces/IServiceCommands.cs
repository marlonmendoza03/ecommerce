using Repository.RepositoryDTO;
using Services.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IServiceCommands
    {
        Task<ProductCommandsResponse> AddProduct(ProductCommands productCommands);
        Task<ProductCommandsResponse> UpdateProduct(ProductCommands productCommands);
        Task<ProductCommandsResponse> DeleteProduct(ProductCommands productCommands);

        void PlaceOrder(List<ShoppingCart> shoppingCart);
    }
}
