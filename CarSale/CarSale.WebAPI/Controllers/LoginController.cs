using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSale.Core.Application_Service.Interface;
using CarSale.Core.Domain_Service.Interface;
using CarSale.Core.Entity.Login;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarSale.WebAPI.Controllers
{
    [Route("/login")]
    public class LoginController : Controller
    {
        private IUserRepository userRepository;
        private IAuthenticationService authenticationService;

        public LoginController(IUserRepository repos, IAuthenticationService authHelper)
        {
            userRepository = repos;
            authenticationService = authHelper;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = userRepository.GetAllUsers().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationService.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = authenticationService.GenerateToken(user)
            });
        }
    }
}
