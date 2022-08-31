using Repository.RepositoryDTO;
using Services.ServicesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILoginServiceCommands
    {
        Task<LoginResponse> Login(UserDTO userDto);
        Task<LoginResponse> Register(UserDTO registerDTO);
    }
}
