using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    /// <summary>
    /// UI Action -- Similar to Command
    /// </summary>
    public enum UIAction
    {
        Unknown,
        
        ViewDetails,

        Navigate,

        GoBack,

        GoForward,

        Create,

        Search,

        Delete,

        Update,

        Refresh,

        SelectionChanged,

        ClearResult,
		
        Copy,
    }
}