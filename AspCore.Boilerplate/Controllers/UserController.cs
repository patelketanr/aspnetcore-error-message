using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCore.Boilerplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [HttpGet("User")]
        public IActionResult User()
        {
            var result = this.userBusiness.GetUser(0);
            return Ok(result);
        }

        [HttpGet("Users")]
        public IActionResult Users()
        {
            var result = this.userBusiness.GetUsers(0);
            return Ok(result);
        }
    }
}
