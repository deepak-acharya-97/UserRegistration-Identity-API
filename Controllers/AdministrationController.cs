using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Data.DbModel;
using UserRegistration.Models;
using UserRegistration.Services.Interfaces;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministrationController : ControllerBase
    {
        private readonly IAdminService _adminService;

        private readonly IJwtService _jwtService;

        public AdministrationController(IAdminService adminService, IJwtService jwtService)
        {
            _adminService = adminService;
            _jwtService = jwtService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await _adminService.RegisterEmployee(login);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool result = await _adminService.LoginEmployee(login);
            if (result)
            {
                string token = _jwtService.GenerateSecurityToken(login.UserName);
                return Ok(new { token });
            }
            return BadRequest("Invalid username and password");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("/employees")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            IEnumerable<Employee> employees = await _adminService.GetEmployeeAsync();
            return Ok(employees);
        }
    }
}
