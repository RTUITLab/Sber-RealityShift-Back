using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicApi.Responses
{
    public class ModuleCompactResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime LastEditTime { get; set; }
        public string Creator { get; set; }
        public List<string> Tags { get; set; }
        public ModuleStatus Status { get; set; }
    }
}
