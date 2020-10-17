using System;

namespace Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime LastEditTime { get; set; }
        
        public ModuleGeneralInformation GeneralInformation { get; set; }
        public ModuleTeacherInstructions TeacherInstructions { get; set; }
    }
}
