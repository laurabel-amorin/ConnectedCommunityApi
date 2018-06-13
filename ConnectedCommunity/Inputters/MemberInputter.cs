using ConnectedCommunity.Model;
using ConnectedCommunity.Models.InputModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectedCommunity.Inputters
{
    public class MemberInputter:Inputter<MemberInput, Member>
    {
        public MemberInputter(MemberInput memberInput):base(memberInput)
        {

        }

        public MemberInputter(MemberInput memberInput, int memberId) : base(memberInput, memberId)
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
