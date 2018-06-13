using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectedCommunity.Model.Repositories;
using ConnectedCommunity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectedCommunity.Controllers
{
    public class BaseController : Controller
    {
        private static readonly log4net.ILog logManager = log4net.LogManager
               .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected IActionResult UnsuccessfulResult(OpResult result)
        {
            string message = result.Message ?? string.Empty;
            switch (result.Status)
            {
                case OpStatus.BadRequest:
                    logManager.Error($"BAD REQUEST: MESSAGE:{message} " +
                                     $"URL: " +
                                     $"USER:");
                    return BadRequest(message);
                case OpStatus.NotFound:
                    logManager.Error($"NOT FOUND: MESSAGE:{message} " +
                                     $"URL:" +
                                     $"USER:");
                    return NotFound();
                default:
                    logManager.Error($"INTERNAL SERVER ERROR: MESSAGE:{message} " +
                                     $"URL:" +
                                     $"USER:");
                    return StatusCode(500, message);
            }

        }

    }
}
