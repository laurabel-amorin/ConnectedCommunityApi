using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConnectedCommunity.Model.Repositories
{
    public interface IGroupMemberRepository:IRepository<GroupMember>{
    }

    public class GroupMemberRepository: Repository<GroupMember>, IGroupMemberRepository
    {
        public GroupMemberRepository(AppDataContext context):base(context)
        {
        }
    }
}
