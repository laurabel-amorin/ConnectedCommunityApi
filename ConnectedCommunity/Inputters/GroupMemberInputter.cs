using ConnectedCommunity.Model;
using ConnectedCommunity.Models.InputModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Inputters
{
    public class GroupMemberInputter:Inputter<GroupMemberInput, GroupMember>
    {
        private readonly GroupMemberInput groupMemberInput;
        private readonly int groupMemberId;
        private GroupMember groupMember;

        public GroupMemberInputter(GroupMemberInput groupMemberInput):base(groupMemberInput)
        {

        }

        public GroupMemberInputter(GroupMemberInput groupMemberInput, int groupMemberId) : base(groupMemberInput, groupMemberId)
        {

        }

        public override ValidationResult ValidateNew()
        {
            return ValidationResult.Success;
        }

        public override ValidationResult ValidateUpdate()
        {
            return ValidationResult.Success;
        }

    }
}
