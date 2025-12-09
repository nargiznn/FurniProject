using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers.DTOs.Account;
using Service.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceApp.Controllers.Admin
{
    //[Authorize(Roles= "Admin")]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _accountService.GetUsersAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            return Ok(await _accountService.GetUserByIdAsync(id));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUsers()
        {
            await _accountService.DeleteUsersAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] string id)
        {
            await _accountService.DeleteUserByIdAsync(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> SearchByUsername([FromQuery] string search)
        {
            return Ok(await _accountService.SearchByUserNameAsync(search));
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole()
        {
            await _accountService.CreateRoleAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _accountService.GetRolesAsync());
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRoleById([FromRoute] string id)
        {
            return Ok(await _accountService.GetRoleByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddRoleToUser([FromQuery] UserRoleDto request)
        {
            await _accountService.AddRoleToUserAsync(request);
            return Ok();
        }
    }
}

