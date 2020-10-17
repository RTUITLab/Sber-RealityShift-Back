using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicApi.Responses
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? AnsweredTime { get; set; }
        public DateTime? DoneTime { get; set; }

        public CommentStatus Status { get; set; }
        public string Answer { get; set; }
        public string AnswerAuthor { get; set; }


        public ModulePart Part { get; set; }
        public string PathToField { get; set; }
    }
}
