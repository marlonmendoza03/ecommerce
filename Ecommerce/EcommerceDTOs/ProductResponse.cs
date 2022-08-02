using System.ComponentModel.DataAnnotations;

namespace Ecommerce.EcommerceDTOs
{
    public class ProductResponse
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
