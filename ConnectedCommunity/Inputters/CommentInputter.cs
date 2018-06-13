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
