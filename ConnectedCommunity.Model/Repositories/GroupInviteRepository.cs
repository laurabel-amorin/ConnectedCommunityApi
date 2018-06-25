using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedCommunity.Model.Repositories
{
    public interface IGroupInviteRepository : IRepository<GroupInvite>
    {
    }

    public class GroupInviteRepository : Repository<GroupInvite>, IGroupInviteRepository
    {
        public GroupInviteRepository(AppDataContext context):base(context)
        {
        }
    }
}
