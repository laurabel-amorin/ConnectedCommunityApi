using ConnectedCommunity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.IndexParamModels
{
    public class PostParams : StandardRepoIndexParams<Post>
    {
        public bool archived { get; set; } = false;

        public override IQueryable<Post> ApplyOptions(IQueryable<Post> data)
        {
            data = ApplySearchOptions(data);
            data = ApplyStatusTags(data);
            data = ApplySortAndPaging(data);
            return data;
        }

        public IQueryable<Post> ApplyStatusTags(IQueryable<Post> data)
        {
            data = data.Where(p => ((p.DateArchived != null) == archived));
            return data;
        }
    }
}
