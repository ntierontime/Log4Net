using System;
using System.Runtime.Serialization;

namespace Log4Net.EntityContracts
{
    /// <summary>
    /// definition of Log with parameters of .Net value type.
    /// </summary>
	public interface ILog : ILogIdentifier
	{ 

        System.DateTime Date { get; set; }


        System.String Thread { get; set; }


        System.String Level { get; set; }


        System.String Logger { get; set; }


        System.String Message { get; set; }


        System.String Exception { get; set; }

	}

    /// <summary>
    /// a property defined when <see cref="WithEntityContractLog"/> is used in other classes.
    /// </summary>
    /// <typeparam name="T">a type inherits from <see cref="WithEntityContractLog"/></typeparam>
	public interface WithEntityContractLog<T>
        where T : ILog
    {
        /// <summary>
        /// Gets or sets the Log
        /// </summary>
        /// <value>
        /// The Log
        /// </value>
        T Log { get; set; }
    }
}

