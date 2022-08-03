using Repository.Interfaces;
using Services.Interfaces;
using Services.ServicesDTO;

namespace Services.Login
{
    public partial class LoginServiceCommands : ILoginServiceCommands
    {
        private readonly ILoginRepositoryQuery _productRepositoryQueries;

        public LoginServiceCommands(ILoginRepositoryQuery productRepositoryQueries)
        {
            _productRepositoryQueries = productRepositoryQueries;
        }

        private async Task<LoginResponse> MapLoginResponse(UserDTO userDTO)
        {
            var user = await _productRepositoryQueries.GetUserWithUsernameAndPassword(userDTO.username, userDTO.password);

            var result = new LoginResponse()
            {
                user_id = user.user_id,
                username = user.username,
                roletype = user.roletype,
                isActive = user.isActive
            };
            return result;
        }
    }
}
