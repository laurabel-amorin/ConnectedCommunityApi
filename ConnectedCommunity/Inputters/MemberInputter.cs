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
    public class MemberInputter:Inputter<MemberInput, Member, IMemberRepository>
    {
        public MemberInputter(IMemberRepository memberRepo, MemberInput memberInput):base(memberRepo, memberInput)
        {

        }

        public MemberInputter(IMemberRepository memberRepo, MemberInput memberInput, Member currentMember)
            :base(memberRepo, memberInput, currentMember)
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
