using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Infra.Data.data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsSetupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManaegr;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<ClaimsSetupController> _logger;

        public ClaimsSetupController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<ClaimsSetupController> logger
            )
        {
            _context = context;
            _userManaegr = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllClaims(string email)
        {
            var user = await _userManaegr.FindByEmailAsync(email);

            if (user == null)
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new 
                {
                    error = "User does not exist"
                });
            }
            var userClaims = await _userManaegr.GetClaimsAsync(user);
            return Ok(userClaims);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserClaims(string email, string ClaimName, string ClaimValue)
        {
            var user = await _userManaegr.FindByEmailAsync(email);
            
            // Check if User Exist! 
            if (user == null)
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new 
                {
                    error = "User does not exist"
                });
            }
            
            var userClaim = new Claim(ClaimName, ClaimValue);
            var result = await _userManaegr.AddClaimAsync(user, userClaim);
            if(result.Succeeded)
            {
                return Ok(new 
                {
                    result = $"User{user.Email} has a claim {ClaimName} added to them"
                });
            }

            return BadRequest(new 
                {
                    error = $"Unable to add {ClaimName} to the {user.Email}!"
                });
        }

       
    }
}