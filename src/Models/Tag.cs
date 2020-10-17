using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Tag
    {
        public int ModuleId{ get; set; }
        public Module Module { get; set; }
        public string Value { get; set; }
    }
}
