using Repository.Interfaces;
using Services.Interfaces;
using Services.ServicesDTO;

namespace Services.Login
{
    public partial class LoginServiceCommands : ILoginServiceCommands
    {
        private readonly ILoginRepositoryQuery _loginRepositoryQuery;

        public LoginServiceCommands(ILoginRepositoryQuery loginRepositoryQuery)
        {
            _loginRepositoryQuery = loginRepositoryQuery;
        }

        private async Task<LoginResponse> MapLoginResponse(UserDTO userDTO)
        {
            var user = await _loginRepositoryQuery.GetUserWithUsernameAndPassword(userDTO.username, userDTO.password);

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
