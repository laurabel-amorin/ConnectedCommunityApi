using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using ConnectedCommunity.Models.InputModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Inputters
{
    public class GroupMemberInputter:Inputter<GroupMemberInput, GroupMember, IGroupMemberRepository>
    {

        public GroupMemberInputter(IGroupMemberRepository groupMemberRepo, GroupMemberInput groupMemberInput)
            :base(groupMemberRepo, groupMemberInput)
        {

        }

        public GroupMemberInputter(IGroupMemberRepository groupMemberRepo, GroupMemberInput groupMemberInput, GroupMember currentGroupMember)
            :base(groupMemberRepo, groupMemberInput, currentGroupMember)
        {

        }

        public override async Task<ValidationResult> ValidateNew()
        {
            return ValidationResult.Success;
        }

        public override async Task<ValidationResult> ValidateUpdate()
        {
            return ValidationResult.Success;
        }

    }
}
