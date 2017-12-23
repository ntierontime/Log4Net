using System;
using System.Runtime.Serialization;

namespace Log4Net.DataSourceEntities
{
    /// <summary>
    /// table/entity identifier, inherit from entity interface, <see cref="Log4Net.EntityContracts.ILogIdentifier"/>
    /// </summary>
    public partial class LogIdentifier
        : Log4Net.EntityContracts.ILogIdentifier
    {

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LogIdentifier"/> class.
        /// </summary>
        public LogIdentifier ()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogIdentifier"/> class.
        /// </summary>
        public LogIdentifier (
System.Int64 id)
        {

            this.Id=id;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogIdentifier"/> class.
        /// </summary>
        public LogIdentifier(Log4Net.EntityContracts.ILogIdentifier item)
        {
            Log4Net.EntityContracts.ILogIdentifierHelper.Copy<Log4Net.EntityContracts.ILogIdentifier, LogIdentifier>(item, this);
        }

        #endregion constructors

        #region properties

        public System.Int64 Id { get; set; }

        #endregion properties

        #region override methods

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance, using ToString method in entity contract helper in EntityContract project
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Log4Net.EntityContracts.ILogIdentifierHelper.ToString<LogIdentifier>(this);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance , using Equals method in entity contract helper in EntityContract project
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            bool _retval = obj is LogIdentifier;
            if (_retval == true)
            {
                _retval = Log4Net.EntityContracts.ILogIdentifierHelper.Equals<LogIdentifier, LogIdentifier>(this, (LogIdentifier)obj);
            }
            return _retval;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        #endregion override methods

        #region Method of LogIdentifier GetAClone()

        /// <summary>
        /// Gets the A clone, using clone method in entity contract helper in EntityContract project.
        /// </summary>
        /// <returns>a new instance of <see cref="LogIdentifier"/></returns>
        public LogIdentifier GetAClone()
        {
            return Log4Net.EntityContracts.ILogIdentifierHelper.Clone<LogIdentifier, LogIdentifier>(this);
        }

        #endregion Method of LogIdentifier GetAClone()
    }
}

