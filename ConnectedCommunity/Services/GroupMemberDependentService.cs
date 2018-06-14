using ConnectedCommunity.Components;
using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Services
{
    public abstract class GroupMemberDependentService:MemberAndGroupDependentService
    {
        private readonly IGroupMemberRepository groupMemberRepo;
        protected GroupMember groupMember;

        public GroupMemberDependentService(IGroupRepository groupRepo, IMemberRepository memberRepo,
            IGroupMemberRepository groupMemberRepo):base(groupRepo, memberRepo)
        {
            this.groupMemberRepo = groupMemberRepo;
        }

        protected async Task<ValidationResult> ValidateGroupMember(int groupMemberId)
        {
            groupMember = await groupMemberRepo.FindAsync(groupMemberId);
            if (groupMember == null)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.GroupMemberDoesNotExist));
            }
            return ValidationResult.Success;
        }

        protected async Task<ValidationResult> ValidateGroupMember(int groupId, int memberId)
        {
            var groupMembers = await groupMemberRepo.GetAsync(gm=>(gm.GroupId==groupId)&&(gm.MemberId==memberId));
            if (groupMembers.Any())
            {
                groupMember = groupMembers.First();
                if (groupMember != null)
                {
                    return ValidationResult.Success;                   
                }
            }
            return new ValidationResult(MessageStrings.GetMessage(MessageStrings.GroupDoesNotExist));
        }

        protected async Task<ValidationResult> ValidateActiveGroupMember(int groupMemberId)
        {
            var validateGroupMemberResult = await ValidateGroupMember(groupMemberId);
            if (validateGroupMemberResult != ValidationResult.Success)
            {
                return validateGroupMemberResult;
            }
            if (!groupMember.Active)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.GroupMemberInactive));
            }
            return ValidationResult.Success;
        }

        protected async Task<ValidationResult> ValidateActiveGroupMember(int groupId, int memberId)
        {
            var validateGroupMemberResult = await ValidateGroupMember(groupId, memberId);
            if (validateGroupMemberResult != ValidationResult.Success)
            {
                return validateGroupMemberResult;
            }
            if (!groupMember.Active)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.GroupMemberInactive));
            }
            return ValidationResult.Success;
        }
    }
}
