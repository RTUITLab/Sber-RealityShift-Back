using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database;
using Models;
using PublicApi.Responses;
using PublicApi.Requests;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Api.Controllers
{
    [Route("api/modules/{moduleId:int}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly SberDbContext dbContext;
        private readonly IMapper mapper;

        public CommentsController(SberDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentResponse>>> GetComments(int moduleId)
        {
            return await dbContext.Comments
                .Where(c => c.ModuleId == moduleId)
                .ProjectTo<CommentResponse>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<CommentResponse>> PostComment(
            [FromRoute] int moduleId,
            [FromBody] CreateCommentRequest request,
            [FromHeader(Name = "UserName")] string username = "server_noname")
        {
            var comment = new Comment
            {
                CreatedTime = DateTime.UtcNow,
                Author = username,
                ModuleId = moduleId,
                Status = Shared.CommentStatus.Created,
            };
            
            mapper.Map(request, comment);
            dbContext.Comments.Add(comment);

            await dbContext.SaveChangesAsync();

            return Ok(mapper.Map<CommentResponse>(comment));
        }

        [HttpPost("{id:int}/accept")]
        public async Task<ActionResult<CommentResponse>> Complete(
            int moduleId,
            int id,
            [FromHeader(Name = "UserName")] string username = "server_noname")
        {
            var comment = await dbContext.Comments
                .Where(c => c.ModuleId == moduleId)
                .SingleOrDefaultAsync(c => c.Id == id);

            if (comment == null)
            {
                return NotFound("not found comment");
            }

            if (comment.Status != Shared.CommentStatus.Created)
            {
                return BadRequest($"Comment {id} already in status {comment.Status}");
            }

            comment.Status = Shared.CommentStatus.CompleteRequest;
            comment.AnsweredTime = DateTime.UtcNow;
            comment.AnswerAuthor = username;

            await dbContext.SaveChangesAsync();

            return mapper.Map<CommentResponse>(comment);
        }

        [HttpPost("{id:int}/reject")]
        public async Task<ActionResult<CommentResponse>> Reject(
            int moduleId,
            int id,
            [FromBody] string message,
            [FromHeader(Name = "UserName")] string username = "server_noname")
        {
            var comment = await dbContext.Comments
                .Where(c => c.ModuleId == moduleId)
                .SingleOrDefaultAsync(c => c.Id == id);

            if (comment == null)
            {
                return NotFound("not found comment");
            }

            if (comment.Status != Shared.CommentStatus.Created)
            {
                return BadRequest($"Comment {id} already in status {comment.Status}");
            }

            comment.Status = Shared.CommentStatus.RejectRequest;
            comment.AnsweredTime = DateTime.UtcNow;
            comment.AnswerAuthor = username;
            comment.Message = message;

            await dbContext.SaveChangesAsync();

            return mapper.Map<CommentResponse>(comment);
        }

        [HttpPost("{id:int}/done")]
        public async Task<ActionResult<CommentResponse>> Done(int moduleId, int id)
        {
            var comment = await dbContext.Comments
                .Where(c => c.ModuleId == moduleId)
                .SingleOrDefaultAsync(c => c.Id == id);

            if (comment == null)
            {
                return NotFound("not found comment");
            }

            if (comment.Status == Shared.CommentStatus.Done)
            {
                return BadRequest($"Comment {id} already in status {comment.Status}");
            }

            comment.Status = Shared.CommentStatus.Done;
            comment.DoneTime = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return mapper.Map<CommentResponse>(comment);
        }
    }
}
