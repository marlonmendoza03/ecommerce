using Repository.RepositoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ILoginRepositoryQuery
    {
        Task<LoginRepositoryResponse> GetUserWithUsernameAndPassword(string username, string password);
    }
}
