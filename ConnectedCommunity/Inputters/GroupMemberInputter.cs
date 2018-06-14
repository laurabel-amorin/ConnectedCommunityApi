using ConnectedCommunity.Components;
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

        public override ValidationResult ValidateNew()
        {
            if (input.MemberId == 0)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.InvalidMemberId));
            }

            if (input.GroupId == 0)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.InvalidGroupId));
            }
            processedInput = new GroupMember
            {

                DateCreated =DateTime.UtcNow
            };
            return ValidationResult.Success;
        }

        public override ValidationResult ValidateUpdate()
        {
            return new ValidationResult(MessageStrings.GetMessage(MessageStrings.InvalidGroupId));
        }

    }
}
