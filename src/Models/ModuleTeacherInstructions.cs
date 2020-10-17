using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ModuleTeacherInstructions
    {
        public int Id { get; set; }

        public string GeneralMeaning { get; set; }
        public string  ExercisesByLessons { get; set; }
        public string Challenges { get; set; }

        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
