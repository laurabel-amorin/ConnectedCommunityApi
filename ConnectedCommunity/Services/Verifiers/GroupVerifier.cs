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
    public class GroupVerifier
    {
        private readonly IGroupRepository groupRepo;
        public Group Group;

        public GroupVerifier(IGroupRepository groupRepo)
        {
            this.groupRepo = groupRepo;
        }

        public async Task<ValidationResult> VerifyGroup(int groupId)
        {
            Group = await groupRepo.FindAsync(groupId);
            if (Group == null)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.GroupDoesNotExist));
            }
            return ValidationResult.Success;
        }

        public async Task<ValidationResult> VerifyGroupAccessibility(int groupId)
        {
            var validateGroupResult = await VerifyGroup(groupId);
            if (validateGroupResult != ValidationResult.Success)
            {
                return validateGroupResult;
            }
            if (Group.Membership==Membership.Default)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.DefaultGroupMembership));
            }
            return ValidationResult.Success;
        }
    }
}

