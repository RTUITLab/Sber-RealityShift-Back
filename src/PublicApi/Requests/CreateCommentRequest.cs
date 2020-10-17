using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace PublicApi.Requests
{
    public class CreateCommentRequest
    {
        public string Message { get; set; }
        public ModulePart Part { get; set; }
        public string PathToField { get; set; }
    }
}
