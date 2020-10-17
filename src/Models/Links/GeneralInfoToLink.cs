using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Links
{
    public class GeneralInfoToLink
    {
        public int GeneralInformationId { get; set; }
        public ModuleGeneralInformation GeneralInformation { get; set; }
        public int TagId { get; set; }
        public ModuleTag Tag { get; set; }
    }
}
