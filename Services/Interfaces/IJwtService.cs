using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateSecurityToken(string email);
    }
}
