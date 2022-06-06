using JWTTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace JWTTest.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Teachers")]
        [Authorize(Roles = "Teacher")]
        public IActionResult TeachersPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok(currentUser.Role);

        }

        [HttpGet("Students")]
        [Authorize(Roles = "Student")]
        public IActionResult StudentsPoint()
        {
            var currentUser = GetCurrentUser();
            return Ok(currentUser.Role);
        }

        [HttpGet("Public")]
        public IActionResult Public()
        {
            return Ok("Open for all");
        }




        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Id = int.Parse(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value),
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Name = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                    Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }


    }
}
