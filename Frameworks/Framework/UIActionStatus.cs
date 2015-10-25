using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    /// <summary>
    /// UI Action Status
    /// </summary>
    public enum UIActionStatus
    {
        Unknown,

        Launch,
        Starting,
        Success,
        Failed,
        Close,
    }
}