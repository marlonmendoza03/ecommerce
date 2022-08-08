using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.EcommerceDTOs
{
    public class ProductsResponse
    {
        public List<ProductsResponseDTO> Products { get; set; }
    }

    public class ProductsResponseDTO
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string DateAdded { get; set; }
        public string ProductImage1 { get; set; }
        public string ProductImage2 { get; set; }
        public string ProductImage3 { get; set; }
        public bool? IsFeatured { get; set; }
    }
}
