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
    public abstract class MemberAndGroupDependentService
    {
        private readonly IGroupRepository groupRepo;
        private readonly IMemberRepository memberRepo;
        protected Member member;
        protected Group group;

        public MemberAndGroupDependentService(IGroupRepository groupRepo, IMemberRepository memberRepo)
        {
            this.groupRepo = groupRepo;
            this.memberRepo = memberRepo;
        }

        protected async Task<ValidationResult> ValidateGroup(int groupId)
        {
            group = await groupRepo.FindAsync(groupId);
            if (group == null)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.GroupDoesNotExist));
            }
            return ValidationResult.Success;
        }

        protected async Task<ValidationResult> ValidateGroupAccessibility(int groupId)
        {
            var validateGroupResult = await ValidateGroup(groupId);
            if (validateGroupResult != ValidationResult.Success)
            {
                return validateGroupResult;
            }
            if (group.Membership==Membership.Default)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.DefaultGroupMembership));
            }
            return ValidationResult.Success;
        }

        protected async Task<ValidationResult> ValidateMember(int memberId)
        {
            member = await memberRepo.FindAsync(memberId);
            if (member == null)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.MemberDoesNotExist));
            }
            return ValidationResult.Success;
        }

        protected async Task<ValidationResult> ValidateActiveMember(int memberId)
        {
            var validateMemberResult = await ValidateMember(memberId);
            if (validateMemberResult != ValidationResult.Success)
            {
                return validateMemberResult;
            }
            if (!member.Active)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.MemberInactive));
            }
            return ValidationResult.Success;
        }
    }
}

