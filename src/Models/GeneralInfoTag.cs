using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Links
{
    public class GeneralInfoTag
    {
        public int GeneralInformationId { get; set; }
        public ModuleGeneralInformation GeneralInformation { get; set; }
        public string Tag { get; set; }
    }
}
