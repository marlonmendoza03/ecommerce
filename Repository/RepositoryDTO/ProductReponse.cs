namespace Repository.RepositoryDTO
{
    public class ProductReponse
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string? ProductImage1 { get; set; }
        public string? ProductImage2 { get; set; }
        public string? ProductImage3 { get; set; }
        public DateTime DateAdded { get; set; }
        public string? ResultMessage { get; set; }
        public bool isActive { get; set; }
    }
}
