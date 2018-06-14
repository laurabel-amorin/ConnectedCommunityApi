using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Services
{
    public class UsersService
    {
        public bool VerifyUser(int userId)
        {
            return true;
        }

        public string GetDefaultAlias()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
