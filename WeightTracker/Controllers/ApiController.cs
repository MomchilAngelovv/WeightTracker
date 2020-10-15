using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeightTracker.Data;
using WeightTracker.Services;

namespace WeightTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IUsersService usersService;

        public ApiController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Route("userCheck")]
        public ActionResult<int> UserCheck(string name)
        {
            var user = this.usersService.GetUserBy(name);

            if (user == null)
            {
                return 0;
            }

            return user.Id;
        }
    }
}
