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
    public class PostMediaInputter:Inputter<MediaInput, PostMedia, IPostMediaRepository>
    {
        public PostMediaInputter(IPostMediaRepository postMediaRepo, MediaInput postMediaInput)
            :base(postMediaRepo, postMediaInput)
        {

        }

        public PostMediaInputter(IPostMediaRepository postMediaRepo, MediaInput postMediaInput, PostMedia currentPostMedia)
            :base(postMediaRepo, postMediaInput, currentPostMedia)
        {

        }

        public override ValidationResult ValidateNew()
        {
            if (input.OwnerId == 0)
            {
                return new ValidationResult(MessageStrings.Get(MessageStrings.InvalidPostId));
            }

            if (!string.IsNullOrEmpty(input.Media))
            {
                processedInput = new PostMedia
                {
                    PostId = input.OwnerId,
                    Media = input.Media
                };
            }
            return ValidationResult.Success;
        }

        public override ValidationResult ValidateUpdate()
        {
            return new ValidationResult(MessageStrings.Get(MessageStrings.CannotUpdateMedia));
        }

    }
}
