namespace Ecommerce.EcommerceDTOs
{
    public class LogsResponse
    {
        public List<LogsResponseDTO> Logs { get; set; }
    }
    public class LogsResponseDTO
    {
        public int LogId { get; set; }
        public string LogDescription { get; set; }
        public int AddedBy { get; set; }
        public DateTime LogDate { get; set; }
    }
}
