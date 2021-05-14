using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPlayground.Repositories
{
    public interface IAuthRepository
    {
        string GenerateJwtToken(string Username, string Password);
        bool ValidateJwtToken(string Token);
    }
}
