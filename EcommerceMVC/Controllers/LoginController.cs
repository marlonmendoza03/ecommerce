using EcommerceMVC.EcommerceDTOs;
using EcommerceMVC.Exceptions;
using EcommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ServicesDTO;

namespace EcommerceMVC.Controllers
{
    [Route("login")]
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

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            var newAccount = new RegisterRequest();
            return View(newAccount);
        }

        [HttpPost("RegisterAccount")]
        public async Task<IActionResult> RegisterAccount(RegisterRequest register)
        {
            CustomResponse customResponse = new CustomResponse();

            if (register == null)
            {
                return customResponse.ClientErrorResponse();
            }

            var registerAccount = new UserDTO()
            {
                firstname = register.FirstName,
                lastname = register.LastName,
                email = register.Email,
                username = register.Username,
                password = register.Password,
                roletype = "user",
                isActive = true
            };

            var result = await _loginServiceCommands.Register(registerAccount);

            if (result == null)
            {
                return customResponse.ClientErrorResponse();
            }

            if (result.ResultMessage == "Server Error")
            {
                return customResponse.ServerErrorResponse();
            }

            return RedirectToAction(nameof(Login));
        }
    }
}
