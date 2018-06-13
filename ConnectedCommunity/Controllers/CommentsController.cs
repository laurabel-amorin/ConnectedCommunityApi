using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectedCommunity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectedCommunity.Controllers
{
    [Route("api/comments")]
    public class CommentsController : BaseController
    {
        private readonly CommentService commentService;

        public CommentsController(CommentService commentService)
        {
            this.commentService = commentService;
        }

        [Route("~/api/comments")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
