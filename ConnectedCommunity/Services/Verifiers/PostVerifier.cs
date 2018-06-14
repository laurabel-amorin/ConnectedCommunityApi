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
    public class PostVerifier
    {
        private readonly IPostRepository postRepo;
        public Post Post;

        public PostVerifier(IPostRepository postRepo)
        {
            this.postRepo = postRepo;
        }

        public async Task<ValidationResult> VerifyPost(int postId)
        {
            Post = await postRepo.FindAsync(postId);
            if (Post == null)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.PostDoesNotExist));
            }
            return ValidationResult.Success;
        }

        public async Task<ValidationResult> VerifyActivePost(int postId)
        {
            var validatePostResult = await VerifyPost(postId);
            if (validatePostResult != ValidationResult.Success)
            {
                return validatePostResult;
            }
            if (Post.DateArchived!=null)
            {
                return new ValidationResult(MessageStrings.GetMessage(MessageStrings.PostArchived));
            }
            return ValidationResult.Success;
        }
        
    }
}
