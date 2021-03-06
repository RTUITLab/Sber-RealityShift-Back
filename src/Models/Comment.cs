﻿using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Comment
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

        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public ModulePart Part { get; set; }
        public string PathToField { get; set; }
    }
}
