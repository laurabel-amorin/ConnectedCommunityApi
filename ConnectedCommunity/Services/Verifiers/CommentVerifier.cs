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
    public interface ICommentVerifier
    {
        Task<ValidationResult> VerifyComment(int commentId);
    }
    public class CommentVerifier:ICommentVerifier
    {
        private readonly ICommentRepository commentRepo;
        public Comment Comment;

        public CommentVerifier(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        public async Task<ValidationResult> VerifyComment(int commentId)
        {
            var comment = await commentRepo.FindAsync(commentId);
            if (comment == null)
            {
                return new ValidationResult(MessageStrings.Get(MessageStrings.CommentDoesNotExist));
            }
            return ValidationResult.Success;
        }
    }
}
