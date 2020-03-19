using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module_ADR.CustomEntities
{
    public class UserWorkCenter
    {
        public int UserId { get; set; }
        public int WorkCenterId { get; set; }
        public string WorkCenter { get; set; }
        public string User { get; set; }
    }
}
