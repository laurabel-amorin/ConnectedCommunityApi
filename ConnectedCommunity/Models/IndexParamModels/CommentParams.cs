using ConnectedCommunity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Models.IndexParamModels
{
    public class CommentParams : StandardRepoIndexParams<Comment>
    {
        public bool? Private { get; set; } = true;
        public bool? hidden { get; set; }

        public override IQueryable<Comment> ApplyParams(IQueryable<Comment> data)
        {
            data = ApplySearchOptions(data);
            data = ApplyStatusTags(data);
            data = ApplySortAndPaging(data);
            return data;
        }

        public IQueryable<Comment> ApplyStatusTags(IQueryable<Comment> data)
        {
            data = data.Where(c => (Private == null || (c.Private == Private.Value)) && (hidden == null || (c.Hidden == hidden.Value)));
            return data;
        }
    }
}
