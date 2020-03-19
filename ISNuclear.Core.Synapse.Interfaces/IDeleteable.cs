using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISNuclear.Data.Interfaces
{
    public interface IDeleteable
    {
        bool Deleted { get; set; }
    }
}
