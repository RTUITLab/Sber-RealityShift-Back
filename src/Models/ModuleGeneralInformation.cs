using Models.Links;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ModuleGeneralInformation
    {
        public int Id { get; set; }

        public ModuleVisibility Visibility { get; set; }
        public int ClassLevel { get; set; }
        public string Course { get; set; }
        public double LaborIntensity { get; set; }
        public List<GeneralInfoToLink> TagLinks { get; set; }
        public string BasicIdea { get; set; }
        public string ProblemQuestion { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
