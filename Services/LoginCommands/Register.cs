using Repository.RepositoryDTO;
using Services.Interfaces;
using Services.ServicesDTO;
using Services.Validations;

namespace Services.Login
{
    public partial class LoginServiceCommands : ILoginServiceCommands
    {
        public async Task<LoginResponse> Register(UserDTO registerDTO)
        {
            var account = new LoginResponse();
            var serverErrorMsg = "Server Error";
            try
            {
                var response = await _loginRepositoryQuery.RegisterAccount(new Users()
                {
                    firstname = registerDTO.firstname,
                    lastname = registerDTO.lastname,
                    email = registerDTO.email,
                    username = registerDTO.username,
                    password = registerDTO.password,
                    isActive = true,
                    roletype = "user"
                });

                if (response.ResultMessage == serverErrorMsg)
                {
                    account.ResultMessage = serverErrorMsg;
                    return account;
                }

                account = await MapLoginResponse(registerDTO);
                account.ResultMessage = "Success";
            }
            catch (Exception)
            {
                account.ResultMessage = serverErrorMsg;
            }

            return account;
        }
    }
}
