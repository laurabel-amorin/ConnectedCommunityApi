using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Services
{
    public static class UserService
    {
        public static bool VerifyUser(int userId)
        {
            return true;
        }

        public static string GetDefaultAlias()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
