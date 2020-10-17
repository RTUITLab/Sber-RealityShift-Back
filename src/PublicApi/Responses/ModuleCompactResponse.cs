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
    }
}
