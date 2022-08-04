using EcommerceMVC.EcommerceDTOs;
using EcommerceMVC.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ServicesDTO;

namespace EcommerceMVC.Controllers
{
    [Route("login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILoginServiceCommands _loginServiceCommands;

        public LoginController(ILoginServiceCommands loginServiceCommands)
        {
            _loginServiceCommands = loginServiceCommands;
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest logRequest)
        {
            CustomResponse customResponse = new CustomResponse();

            if (logRequest == null)
            {
                return customResponse.LoginErrorResponse();
            }

            var userDto = new UserDTO()
            {
                username = logRequest.username,
                password = logRequest.password
            };
            var result = await _loginServiceCommands.Login(userDto);


            if (result == null)
            {
                return customResponse.LoginErrorResponse();
            }

            if (result.ResultMessage == "Server Error")
            {
                return customResponse.ServerErrorResponse();
            }

            if (result.ResultMessage == "Login failed")
            {
                return customResponse.LoginErrorResponse();
            }

            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUsername)))
            {
                HttpContext.Session.SetString(SessionVariables.SessionKeyUsername, result.username);
                HttpContext.Session.SetString(SessionVariables.SessionKeySessionId, Guid.NewGuid().ToString());
            }

            var username = HttpContext.Session.GetString(SessionVariables.SessionKeyUsername);
            var sessionId = HttpContext.Session.GetString(SessionVariables.SessionKeySessionId);

            var response = new EcommerceDTOs.LoginResponse()
            {
                user_id = result.user_id,
                roletype = result.roletype,
                SessionId = sessionId,
                SessionUsername = username
            };
            return Ok(response);
        }
    }
}
