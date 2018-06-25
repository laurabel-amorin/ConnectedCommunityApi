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
        private readonly IGroupMemberService groupMemberService;

        public GroupMembersController(IGroupMemberService groupMemberService)
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
