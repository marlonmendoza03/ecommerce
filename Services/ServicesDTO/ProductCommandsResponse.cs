using System.ComponentModel.DataAnnotations;

namespace Services.ServicesDTO
{
    public class ProductCommandsResponse
    {
        [Key]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public float ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

        public string? DateAdded { get; set; }

        public string? ResultMessage { get; set; }
        public bool IsActive { get; set; }
    }
}