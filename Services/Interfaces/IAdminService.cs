using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Data.DbModel;
using UserRegistration.Models;

namespace UserRegistration.Services.Interfaces
{
    public interface IAdminService
    {
        Task<bool> RegisterEmployee(Login login);

        Task<bool> LoginEmployee(Login login);

        Task<IEnumerable<Employee>> GetEmployeeAsync();
    }
}
