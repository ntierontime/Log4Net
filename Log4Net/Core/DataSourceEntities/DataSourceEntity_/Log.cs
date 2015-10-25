using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
#if WINDOWS_PHONE
#else
using System.ComponentModel.DataAnnotations;
#endif

namespace Log4Net.DataSourceEntities
{
    /// <summary>
    /// Entity class, used across the solution. <see cref="Log"/>
    /// </summary>
    //[DataContract]
	public partial class Log  : Framework.PropertyChangedNotifier, Log4Net.EntityContracts.ILog 
	{ 





		#region Storage Fields

        public System.Int64 m_Id;

        public System.DateTime m_Date;

        public System.String m_Thread;

        public System.String m_Level;

        public System.String m_Logger;

        public System.String m_Message;

        public System.String m_Exception;


		#endregion Storage Fields


    

		#region constructors

        /// <summary>
        /// default constructor
        /// Initializes a new instance of the <see cref=" Log"/> class.
        /// </summary>
		public Log()
		{
			this.Id = default(long);
			this.Date = DateTime.Now;
			this.Thread = null;
			this.Level = null;
			this.Logger = null;
			this.Message = null;
			this.Exception = null;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref=" Log"/> class with .Net value type parameters.
        /// </summary>
        /// <param name="id">property value of Id</param>
        /// <param name="date">property value of Date</param>
        /// <param name="thread">property value of Thread</param>
        /// <param name="level">property value of Level</param>
        /// <param name="logger">property value of Logger</param>
        /// <param name="message">property value of Message</param>
        /// <param name="exception">property value of Exception</param>
		public Log(
			System.Int64 id
			,System.DateTime date
			,System.String thread
			,System.String level
			,System.String logger
			,System.String message
			,System.String exception
			)
		{
			this.m_Id = id;
			this.m_Date = date;
			this.m_Thread = thread;
			this.m_Level = level;
			this.m_Logger = logger;
			this.m_Message = message;
			this.m_Exception = exception;
		}

        /// <summary>
        /// Initializes/clone a new instance of the <see cref=" Log"/> class.
        /// </summary>
        /// <param name="item">an entity instance with same contract of <see cref=" Log4Net.EntityContracts.ILog"/></param>
        public Log(Log4Net.EntityContracts.ILog item)
        {
            Log4Net.EntityContracts.ILogHelper.Copy<Log4Net.EntityContracts.ILog, Log>(item, this);
        }


		#endregion constructors

		#region properties

				[DataMember]
#if (WINDOWS_PHONE)

#else
		[Display(Name = "Id", ResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog))]
		[RequiredAttribute(ErrorMessageResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog), ErrorMessageResourceName="Id_is_required")]
#endif
        public System.Int64 Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
                RaisePropertyChanged("Id");
            }
        }

				[DataMember]
#if (WINDOWS_PHONE)

#else
		[Display(Name = "Date", ResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog))]
		[RequiredAttribute(ErrorMessageResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog), ErrorMessageResourceName="Date_is_required")]
#endif
        public System.DateTime Date
        {
            get
            {
                return m_Date;
            }
            set
            {
                m_Date = value;
                RaisePropertyChanged("Date");
            }
        }

				[DataMember]
#if (WINDOWS_PHONE)

#else
		[Display(Name = "Thread", ResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog))]
		[RequiredAttribute(ErrorMessageResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog), ErrorMessageResourceName="Thread_is_required")]
#endif
        public System.String Thread
        {
            get
            {
                return m_Thread;
            }
            set
            {
                m_Thread = value;
                RaisePropertyChanged("Thread");
            }
        }

				[DataMember]
#if (WINDOWS_PHONE)

#else
		[Display(Name = "Level", ResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog))]
		[RequiredAttribute(ErrorMessageResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog), ErrorMessageResourceName="Level_is_required")]
#endif
        public System.String Level
        {
            get
            {
                return m_Level;
            }
            set
            {
                m_Level = value;
                RaisePropertyChanged("Level");
            }
        }

				[DataMember]
#if (WINDOWS_PHONE)

#else
		[Display(Name = "Logger", ResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog))]
		[RequiredAttribute(ErrorMessageResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog), ErrorMessageResourceName="Logger_is_required")]
#endif
        public System.String Logger
        {
            get
            {
                return m_Logger;
            }
            set
            {
                m_Logger = value;
                RaisePropertyChanged("Logger");
            }
        }

				[DataMember]
#if (WINDOWS_PHONE)

#else
		[Display(Name = "Message", ResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog))]
		[RequiredAttribute(ErrorMessageResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog), ErrorMessageResourceName="Message_is_required")]
#endif
        public System.String Message
        {
            get
            {
                return m_Message;
            }
            set
            {
                m_Message = value;
                RaisePropertyChanged("Message");
            }
        }

				[DataMember]
#if (WINDOWS_PHONE)

#else
		[Display(Name = "Exception", ResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog))]
#endif
        public System.String Exception
        {
            get
            {
                return m_Exception;
            }
            set
            {
                m_Exception = value;
                RaisePropertyChanged("Exception");
            }
        }


		#endregion properties

        #region override methods

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Log4Net.EntityContracts.ILogHelper.ToString<Log>(this);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            bool _retval = obj is Log;
            if (_retval == true)
            {
                _retval = Log4Net.EntityContracts.ILogHelper.Equals<Log, Log>(this, (Log)obj);
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

		#region Method of Log GetAClone()

        /// <summary>
        /// Gets the A clone.
        /// </summary>
        /// <returns>a new instance with same value</returns>
        public Log GetAClone()
        {
            return Log4Net.EntityContracts.ILogHelper.Clone<Log, Log>(this);
        }


		#endregion Method of Log GetAClone()

		#region Nested Views classes and their collection classes 1


        /// <summary>
        /// View "KeyInformation" class of <see cref="Log"/>, used across the solution. 
        /// </summary>
		public partial class KeyInformation :Framework.PropertyChangedNotifier, Log4Net.EntityContracts.ILogIdentifier
		{

			#region Storage Fields

        public System.Int64 m_Id;


			#endregion Storage Fields

			#region Constructors

			/// <summary>
			/// Initializes/clone a new instance of the <see cref=" Log"/> class.
			/// </summary>
			/// <param name="item">an entity instance with same contract of <see cref=" Log4Net.EntityContracts.ILog"/></param>
			public KeyInformation()
			{
				this.Id = default(long);
			}
			/*
			/// <summary>
			/// Initializes/clone a new instance of the <see cref=" Log"/> class.
			/// </summary>
			/// <param name="item">an entity instance with same contract of <see cref=" Log4Net.EntityContracts.ILog"/></param>
			public KeyInformation(Log4Net.EntityContracts.ILog item)
			{
				Log4Net.EntityContracts.ILogHelper.Copy<Log4Net.EntityContracts.ILog, KeyInformation>(item, this);
			}
			*/
			#endregion Constructors


			#region properties

					[DataMember]
#if (WINDOWS_PHONE)

#else
		[Display(Name = "Id", ResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog))]
		[RequiredAttribute(ErrorMessageResourceType = typeof(Log4Net.Resources.UIStringResourcePerEntityLog), ErrorMessageResourceName="Id_is_required")]
#endif
        public System.Int64 Id
        {
            get
            {
                return m_Id;
            }
            set
            {
                m_Id = value;
                RaisePropertyChanged("Id");
            }
        }


			#endregion properties

            #region Method of Log.KeyInformation  GetAClone()

            /// <summary>
            /// Gets the A clone.
            /// </summary>
            /// <returns>a new instance with same value</returns>
            public KeyInformation GetAClone()
            {
                KeyInformation cloned = new KeyInformation();

			cloned.m_Id = m_Id;

                return cloned;
            }


            #endregion Method of Log.KeyInformation  GetAClone()
		}

        /// <summary>
        /// View "KeyInformation" class of <see cref="Log"/>, used across the solution. 
        /// </summary>
		public partial class KeyInformationCollection
			:  List<KeyInformation>
		{ 
		}

        /// <summary>
        /// message definition of "KeyInformation", pass single entry, from database, to business logic layer. <see cref="Log"/> and <see cref="Framework.DataAccessLayerMessageBase&lt;T&gt;"/>
        /// </summary>
		public class DataAccessLayerMessageOfKeyInformation
			: Framework.DataSourceEntities.DataAccessLayerMessageBase<KeyInformation>
		{
		}

        /// <summary>
        /// message definition of "KeyInformation", pass a collection of instances, from database, to business logic layer. <see cref="Log"/> and <see cref="Framework.DataAccessLayerMessageBase&lt;T&gt;"/>
        /// </summary>
		public class DataAccessLayerMessageOfKeyInformationCollection
			: Framework.DataSourceEntities.DataAccessLayerMessageBase<KeyInformationCollection>
		{
		}




		#endregion Nested Views classes and their collection classes 1

	}



    /// <summary>
    /// a property defined when <see cref="Log"/> is used in other classes.
    /// </summary>
	public interface WithEntityContractLog
	{ 
        /// <summary>
        /// Gets or sets Log.
        /// </summary>
        /// <value>
        /// The Log
        /// </value>
		Log Log { get; set; }
	}

    /// <summary>
    /// message definition, pass single entry, pulled from database, to business logic layer. <see cref="Log"/> and <see cref="Framework.DataAccessLayerMessageBase&lt;T&gt;"/>
    /// </summary>
    public class DataAccessLayerMessageOfEntityLog
        : Framework.DataSourceEntities.DataAccessLayerMessageBase<Log>
    {
    }
}