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
    public class CommentMediaInputter:Inputter<MediaInput, CommentMedia, ICommentMediaRepository>
    {
        public CommentMediaInputter(ICommentMediaRepository commentMediaRepo, MediaInput commentMediaInput)
            :base(commentMediaRepo, commentMediaInput)
        {

        }

        public CommentMediaInputter(ICommentMediaRepository commentMediaRepo, MediaInput commentMediaInput, CommentMedia currentCommentMedia)
            :base(commentMediaRepo, commentMediaInput, currentCommentMedia)
        {

        }

        public override ValidationResult ValidateNew()
        {
            
            return ValidationResult.Success;
        }

        public override ValidationResult ValidateUpdate()
        {
            return new ValidationResult(MessageStrings.GetMessage(MessageStrings.CannotUpdateMedia));
        }

    }
}
