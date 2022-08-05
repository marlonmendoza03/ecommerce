using Services.Interfaces;
using Services.ServicesDTO;

namespace Services.Login
{
    public partial class LoginServiceCommands : ILoginServiceCommands
    {
        public async Task<LoginResponse> Login(UserDTO userDTO)
        {
            var loginResponse = new LoginResponse();
            var serverErrorMsg = "Server Error";

            try
            {
            var user = await _loginRepositoryQuery.GetUserWithUsernameAndPassword(userDTO.username.ToLower(), userDTO.password);
            if (user != null || user.isActive == true)
            {
                if (user.username.ToLower() == userDTO.username.ToLower() && user.password == user.password)
                {
                    loginResponse = await MapLoginResponse(userDTO);
                }
            }
                if (user.ResultMessage == serverErrorMsg)
                {
                    loginResponse.ResultMessage = serverErrorMsg;
                    return loginResponse;
                }
                loginResponse.ResultMessage = "Success";
            }
            catch (Exception e)
            {
                loginResponse.ResultMessage = serverErrorMsg;
            }
            return loginResponse;
        }
    }
}
