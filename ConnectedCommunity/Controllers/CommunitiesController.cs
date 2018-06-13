using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectedCommunity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectedCommunity.Controllers
{
    [Route("api/communities")]
    public class CommunitiesController : BaseController
    {
        private readonly CommunityService communityService;

        public CommunitiesController(CommunityService communityService)
        {
            this.communityService = communityService;
        }

        [Route("~/api/communities")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
