﻿using ConnectedCommunity.Components;
using ConnectedCommunity.Model;
using ConnectedCommunity.Model.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Services
{
    public interface IGroupMemberVerifier
    {
        Task<ValidationResult> VerifyGroupMember(int groupMemberId);
        Task<ValidationResult> VerifyGroupMember(int groupId, int memberId);
        Task<ValidationResult> VerifyActiveGroupMember(int groupMemberId);
    }

    public class GroupMemberVerifier:IGroupMemberVerifier
    {
        private readonly IGroupMemberRepository groupMemberRepo;
        public GroupMember GroupMember;

        public GroupMemberVerifier(IGroupMemberRepository groupMemberRepo)
        {
            this.groupMemberRepo = groupMemberRepo;
        }

        public async Task<ValidationResult> VerifyGroupMember(int groupMemberId)
        {
            GroupMember = await groupMemberRepo.FindAsync(groupMemberId);
            if (GroupMember == null)
            {
                return new ValidationResult(MessageStrings.Get(MessageStrings.GroupMemberDoesNotExist));
            }
            return ValidationResult.Success;
        }

        public async Task<ValidationResult> VerifyGroupMember(int groupId, int memberId)
        {
            var groupMembers = await groupMemberRepo.GetAsync(gm=>(gm.GroupId==groupId)&&(gm.MemberId==memberId));
            if (groupMembers.Any())
            {
                GroupMember = groupMembers.First();
                if (GroupMember != null)
                {
                    return ValidationResult.Success;                   
                }
            }
            return new ValidationResult(MessageStrings.Get(MessageStrings.GroupDoesNotExist));
        }

        public async Task<ValidationResult> VerifyActiveGroupMember(int groupMemberId)
        {
            var validateGroupMemberResult = await VerifyGroupMember(groupMemberId);
            if (validateGroupMemberResult != ValidationResult.Success)
            {
                return validateGroupMemberResult;
            }
            if (!GroupMember.Active)
            {
                return new ValidationResult(MessageStrings.Get(MessageStrings.GroupMemberInactive));
            }
            return ValidationResult.Success;
        }

        protected async Task<ValidationResult> VerifyActiveGroupMember(int groupId, int memberId)
        {
            var validateGroupMemberResult = await VerifyGroupMember(groupId, memberId);
            if (validateGroupMemberResult != ValidationResult.Success)
            {
                return validateGroupMemberResult;
            }
            if (!GroupMember.Active)
            {
                return new ValidationResult(MessageStrings.Get(MessageStrings.GroupMemberInactive));
            }
            return ValidationResult.Success;
        }
    }
}
