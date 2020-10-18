using Shared;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime LastEditTime { get; set; }
        public string Creator { get; set; }
        public bool Done { get; set; }


        public ModuleVisibility Visibility { get; set; }
        public int ClassLevel { get; set; }
        public string Course { get; set; }
        public double LaborIntensity { get; set; }
        public List<Tag> Tags { get; set; }
        public string BasicIdea { get; set; }
        public string ProblemQuestion { get; set; }

        public ModuleTeacherInstructions TeacherInstructions { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
