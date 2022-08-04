namespace EcommerceMVC.EcommerceDTOs
{
    public class LoginResponse
    {
        public int user_id { get; set; }
        public string roletype { get; set; }
        public string SessionId { get; set; }
        public string SessionUsername { get; set; }
    }
}
