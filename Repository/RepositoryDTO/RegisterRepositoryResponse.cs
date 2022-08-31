namespace Repository.RepositoryDTO
{
    public class RegisterRepositoryResponse
    {
        public string firstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RetypePassword { get; set; }
        public string roletype { get; set; }
        public bool isActive { get; set; }
        public string? ResultMessage { get; set; }
    }
}
