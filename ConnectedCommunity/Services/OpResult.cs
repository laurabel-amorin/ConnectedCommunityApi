using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Services
{
    public enum OpStatus
    {
        Ok, BadRequest, NotFound, Error
    }

    public abstract class OpResult
    {
        public OpStatus? Status { get; set; }
        public string Message { get; set; }

    }
}
