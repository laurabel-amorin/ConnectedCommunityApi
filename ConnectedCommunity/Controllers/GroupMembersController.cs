using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectedCommunity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectedCommunity.Controllers
{
    [Route("api/groupMembers")]
    public class GroupMembersController : BaseController
    {
        private readonly GroupMemberService groupMemberService;

        public GroupMembersController(GroupMemberService groupMemberService)
        {
            this.groupMemberService = groupMemberService;
        }

        [Route("~/api/groupMembers")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
