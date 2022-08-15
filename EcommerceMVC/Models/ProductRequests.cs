namespace EcommerceMVC.EcommerceDTOs
{
    public class ProductRequest
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductProc { get; set; }
        public int ProductRam { get; set; }
        public int ProductStorage { get; set; }
    }
}
