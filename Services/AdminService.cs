using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserRegistration.Data;
using UserRegistration.Data.DbModel;
using UserRegistration.Models;
using UserRegistration.Services.Interfaces;

namespace UserRegistration.Services
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly EmployeeDbContext _dbContext;

        public AdminService(UserManager<IdentityUser> userManager, EmployeeDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<bool> LoginEmployee(Login login)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(login.UserName);
            if(user == null)
            {
                return false;
            }
            bool result = await _userManager.CheckPasswordAsync(user, login.Password);
            return result;
        }

        public async Task<bool> RegisterEmployee(Login login)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = login.UserName,
                Email = login.UserName
            };

            IdentityResult result = await _userManager.CreateAsync(user, login.Password);
            return result.Succeeded;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            return await _dbContext.Employees.ToListAsync();
        }
    }
}
