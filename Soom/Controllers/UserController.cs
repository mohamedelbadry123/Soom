using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Interfaces.ViewModel.UserVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Interfaces.Interfaces;

namespace Aknan.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ICoreBase _repoCore;
        

        public UserController(UserManager<Users> userManager,
                              RoleManager<IdentityRole> roleManager,
                              IConfiguration configuration,
                              ICoreBase repoCore)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _repoCore = repoCore;
        }

        [Authorize]
        public IActionResult GetAllUsesWithRoleUser()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult GetAllUsesWithRoleAdmin()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult GetAllUsesWithRoleSales()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult GetAllUsesWithRoleTechnical()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreateUser()
        {
            var model = new RegisterViewModel();

            return View(model);
        }

        //[HttpGet]
        //[Authorize]
        //public IActionResult ChangePassword()
        //{
        //    var model = new ChangePasswordViewModel();

        //    return View(model);
        //}

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var user = await _userManager.FindByNameAsync(model.Username);
        //    if (user != null && await _userManager.CheckPasswordAsync(user, model.OldPassword))
        //    {

        //        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        //        var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
        //        if(result.Succeeded)
        //            return RedirectToAction("GetAllUsesWithRoleUser");
        //    }

        //    model.Error = "خطأ فى اسم المستخدم او الرقم السرى السابق !";
        //    return View(model);
        //}


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if(string.IsNullOrEmpty(model.Email) || string.IsNullOrWhiteSpace(model.Email))
            {
                model.Error = "ادخل اسم المستخدم !";
                return View(model);
            }

            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrWhiteSpace(model.Password))
            {
                model.Error = "ادخل الرقم السرى !";
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    authClaims.Add(new Claim("id", user.Id));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                HttpContext.Session.SetString("JWToken", new JwtSecurityTokenHandler().WriteToken(token));

                return RedirectToAction("Index", "Home");
            }

            model.Error = "خطأ فى اسم المستخدم او الرقم السرى ";
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateUser", model);
            }

            var userInDb = await _userManager.FindByEmailAsync(model.Email);
            if(userInDb != null)
            {
                model.Error = "تم ادخال هذا البريد الألكترونى من قبل !";
                return View("CreateUser", model);
            }

            var emailSperated = model.Email.Split('@');
            var username = emailSperated[0] + _repoCore.GenerateRandomCodeAsNumber(); 
            var user = new Users()
            {
                Name = model.Name,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                model.Error = "حدث خطأ فى انشاء المستخدم رجاء مراجعه البيانات والمحاولة مرة اخرى !";
                return View("CreateUser", model);
            }

            if(model.Role == "admin")
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _userManager.AddToRoleAsync(user, "Admin");
                return RedirectToAction("GetAllUsesWithRoleAdmin");
            }
            else if(model.Role == "technical")
            {
                await _roleManager.CreateAsync(new IdentityRole("Technical"));
                await _userManager.AddToRoleAsync(user, "Technical");
                return RedirectToAction("GetAllUsesWithRoleTechnical");
            }
            else if(model.Role == "sales")
            {
                await _roleManager.CreateAsync(new IdentityRole("Sales"));
                await _userManager.AddToRoleAsync(user, "Sales");
                return RedirectToAction("GetAllUsesWithRoleSales");
            }
            else
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
                await _userManager.AddToRoleAsync(user, "User");
                return RedirectToAction("GetAllUsesWithRoleUser");
            }
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
