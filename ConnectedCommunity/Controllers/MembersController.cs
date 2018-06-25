using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectedCommunity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectedCommunity.Controllers
{
    [Route("api/members")]
    public class MembersController : BaseController
    {
        private readonly IMemberService memberService;

        public MembersController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        [Route("~/api/members")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
