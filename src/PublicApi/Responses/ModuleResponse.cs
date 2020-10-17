using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicApi.Responses
{
    public class ModuleResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime LastEditTime { get; set; }
        public string Creator { get; set; }

        public PartInfo GeneralPart { get; set; }
        public PartInfo TeacherInstructionsPart { get; set; }


        public ModuleVisibility Visibility { get; set; }
        public int ClassLevel { get; set; }
        public string Course { get; set; }
        public double LaborIntensity { get; set; }
        public List<string> Tags { get; set; }
        public string BasicIdea { get; set; }
        public string ProblemQuestion { get; set; }
    }
}
