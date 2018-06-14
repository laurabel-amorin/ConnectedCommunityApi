using ConnectedCommunity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.IndexParamModels
{
    public class GroupMemberParams : StandardRepoIndexParams<GroupMember>
    {
        public bool active { get; set; } = true;
        public bool? admin { get; set; }

        public override IQueryable<GroupMember> ApplyParams(IQueryable<GroupMember> data)
        {
            data = ApplySearchOptions(data);
            data = ApplyStatusTags(data);
            data = ApplySortAndPaging(data);
            return data;
        }

        public IQueryable<GroupMember> ApplyStatusTags(IQueryable<GroupMember> data)
        {
            data = data.Where(m => (admin == null || (m.Admin == admin.Value)) && (m.Active == active));
            return data;
        }
    }
}
