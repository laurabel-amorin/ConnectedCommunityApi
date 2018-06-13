using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectedCommunity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectedCommunity.Controllers
{
    [Route("api/groups")]
    public class GroupsController : BaseController
    {
        private readonly GroupService groupService;

        public GroupsController(GroupService groupService)
        {
            this.groupService = groupService;
        }

        [Route("~/api/groups")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
