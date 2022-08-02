namespace Ecommerce.EcommerceDTOs
{
    public class GetAllProducts
    {
        public List<GetAllProductsDTO> Products { get; set; }
    }

    public class GetAllProductsDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
