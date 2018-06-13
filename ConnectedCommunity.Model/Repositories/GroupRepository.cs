using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedCommunity.Model.Repositories
{
    public interface IGroupRepository:IRepository<Group>{
    }

    public class GroupRepository: Repository<Group>, IGroupRepository
    {
        public GroupRepository(AppDataContext context):base(context)
        {
        }
    }
}
