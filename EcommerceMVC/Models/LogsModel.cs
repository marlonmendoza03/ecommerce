namespace EcommerceMVC.EcommerceDTOs
{
    public class LogsResponseModel
    {
        public List<LogsModel> Logs { get; set; }
    }
    public class LogsModel
    {
        public int LogId { get; set; }
        public string LogDescription { get; set; }
        public int AddedBy { get; set; }
        public DateTime LogDate { get; set; }
    }
}
