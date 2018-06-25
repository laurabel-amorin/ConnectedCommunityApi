using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectedCommunity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectedCommunity.Controllers
{
    [Route("api/posts")]
    public class PostsController : BaseController
    {
        private readonly IPostService postService;

        public PostsController(IPostService postService)
        {
            this.postService = postService;
        }

        [Route("~/api/posts")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Json("hi"));
        }
    }
}
