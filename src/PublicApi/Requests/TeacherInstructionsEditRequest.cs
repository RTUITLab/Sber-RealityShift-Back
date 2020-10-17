using System;
using System.Collections.Generic;
using System.Text;

namespace PublicApi.Responses
{
    public class TeacherInstructionsEditRequest
    {
        public string GeneralMeaning { get; set; }
        public string ExercisesByLessons { get; set; }
        public string Challenges { get; set; }
    }
}
