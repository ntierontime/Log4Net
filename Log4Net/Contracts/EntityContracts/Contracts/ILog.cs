using System;
using System.Runtime.Serialization;

namespace Log4Net.EntityContracts
{
    /// <summary>
    /// definition of Log with parameters of .Net value type.
    /// </summary>
    public partial interface ILog : ILogIdentifier
    {

        System.DateTime Date { get; set; }

        System.String Thread { get; set; }

        System.String Level { get; set; }

        System.String Logger { get; set; }

        System.String Message { get; set; }

        System.String Exception { get; set; }

    }
}

