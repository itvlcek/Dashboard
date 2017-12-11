using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dashboard.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Dashboard.Logic.DbModel;

namespace Dashboard.Controllers
{
    public class TokenController : Controller
    {
        private IConfiguration Configuration { get; set; }

        private UserManager<ApplicationUser> UserManager { get; set; }

        private SignInManager<ApplicationUser> SignInManager { get; set; }

        public TokenController(IConfiguration configuration, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            Configuration = configuration;
            UserManager = usermanager;
            SignInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Get(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await SignInManager.CheckPasswordSignInAsync
                                    (user, model.Password, lockoutOnFailure: false);

                    if (!result.Succeeded)
                    {
                        return Unauthorized();
                    }

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, model.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var token = new JwtSecurityToken
                    (
                        issuer: Configuration["Token:Issuer"],
                        audience: Configuration["Token:Audience"],
                        claims: claims,
                        expires: DateTime.UtcNow.AddDays(60),
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(new SymmetricSecurityKey
                                    (Encoding.UTF8.GetBytes(Configuration["Token:Key"])),
                                SecurityAlgorithms.HmacSha256)
                    );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
            }

            return BadRequest();
        }
    }
}

