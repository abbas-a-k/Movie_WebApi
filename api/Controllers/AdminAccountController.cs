using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Admin;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/adminaccount")]
    [ApiController]
    public class AdminAccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;
        public AdminAccountController(UserManager<AppUser> userManager,ITokenService tokenService,SignInManager<AppUser> signinManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signinManager = signinManager;
        }


        [HttpPost("adminlogin")]
        public async Task<IActionResult> AdminLogin(AdminLoginDto adminLoginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var admin = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == adminLoginDto.Username.ToLower());

            if (admin == null ) return Unauthorized("Invalid username!");

            var isInRole =  await _userManager.IsInRoleAsync(admin,"Admin");
            
            if (!isInRole) return Unauthorized("Invalid role!");

            var result = await _signinManager.CheckPasswordSignInAsync(admin, adminLoginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

            return Ok(
                new NewAdminDto
                {
                    UserName = adminLoginDto.Username,
                    Token = _tokenService.CreateAdminToken(admin)
                }
            );
        }


        [HttpPost("adminregister")]
        public async Task<IActionResult> AdminRegister([FromBody] AdminRegisterDto adminRegisterDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var admin = new AppUser
                {
                    UserName = adminRegisterDto.Username,
                };

                var createdAdmin = await _userManager.CreateAsync(admin, adminRegisterDto.Password);

                if (createdAdmin.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(admin, "Admin");
                    if (roleResult.Succeeded)
                    {
                        return Ok(
                            new NewAdminDto
                            {
                                UserName = admin.UserName,
                                Token = _tokenService.CreateAdminToken(admin)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdAdmin.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


    }
}