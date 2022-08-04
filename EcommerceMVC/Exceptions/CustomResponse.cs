using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Exceptions
{
    public class CustomResponse : ControllerBase
    {
        public IActionResult ClientErrorResponse()
        {
            return BadRequest(new CustomErrors()
            {
                Result = new Result()
            });
        }

        public ObjectResult ServerErrorResponse()
        {
            return StatusCode(500, new CustomErrors
            {
                Result = new Result
                {
                    Message = "Internal Server Error."
                }
            });
        }

        public ObjectResult LoginErrorResponse()
        {
            return StatusCode(401, new CustomErrors
            {
                Result = new Result
                {
                    Message = "Login failed"
                }
            });
        }
    }
}
