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
    public class CommentInputter:Inputter<CommentInput, Comment, ICommentRepository>
    {
        public CommentInputter(ICommentRepository commentRepo, CommentInput commentInput)
            :base(commentRepo, commentInput)
        {

        }

        public CommentInputter(ICommentRepository commentRepo, CommentInput commentInput, Comment currentComment) 
            :base(commentRepo, commentInput, currentComment)
        {

        }

        public override ValidationResult ValidateNew()
        {
            if (input.GroupId == 0)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.InvalidGroupId));
            }

            if (input.MemberId == 0)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.InvalidMemberId));
            }

            if (string.IsNullOrEmpty(input.Content))
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.CommentContentEmpty));
            }

            return ValidationResult.Success;
        }

        public override ValidationResult ValidateUpdate()
        {
            return ValidationResult.Success;
        }

    }
}
