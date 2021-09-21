using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orangular.DTO.Login.Requests;
using Orangular.DTO.Login.Responses;
using Orangular.DTO.Users.Responses;
using Orangular.Services.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orangular.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // Authenticate
        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> Authenticate(LoginRequest login)
        //{
        //    try
        //    {
        //        LoginResponse response = await _userService.Authenticate(login);
        //        if (response == null) return Unauthorized();
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem(ex.Message);
        //    }
        //}

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<UsersResponse> users = await _userService.GetAll();
                if (users == null) return Problem("No data received, null was returned");
                if (users.Count == 0) return NoContent();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // GetById
        [HttpGet("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int userId)
        {
            try
            {
                // NOT IMPLEMENTED YET!
                // Only admins can access other user records
                // var currentUser = (UsersResponse)HttpContext.Items["User"];
                // if (userId != currentUser.users_id && currentUser.role != Helpers.Role.Admin) return Unauthorized(new { message = "Unauthorized" });
                UsersResponse user = await _userService.GetById(userId);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        // Create
        // Update
        // Delete

    }
}
