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
    public class MemberVerifier
    {
        private readonly IMemberRepository memberRepo;
        public Member Member;

        public MemberVerifier(IMemberRepository memberRepo)
        {
            this.memberRepo = memberRepo;
        }

        public async Task<ValidationResult> VerifyMember(int memberId)
        {
            Member = await memberRepo.FindAsync(memberId);
            if (Member == null)
            {
                return new ValidationResult(MessageStrings.Get(MessageStrings.MemberDoesNotExist));
            }
            return ValidationResult.Success;
        }

        public async Task<ValidationResult> VerifyActiveMember(int memberId)
        {
            var validateMemberResult = await VerifyMember(memberId);
            if (validateMemberResult != ValidationResult.Success)
            {
                return validateMemberResult;
            }
            if (!Member.Active)
            {
                return new ValidationResult(MessageStrings.Get(MessageStrings.MemberInactive));
            }
            return ValidationResult.Success;
        }
    }
}

