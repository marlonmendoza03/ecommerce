using System.ComponentModel.DataAnnotations;

namespace Ecommerce.EcommerceDTOs
{
    public class ProductResponse
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string? DateAdded { get; set; }
    }
}
