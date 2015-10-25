#pragma warning disable 1591
namespace Log4Net.LinqToSqlContexts
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	public partial class Log4NetContext : System.Data.Linq.DataContext
	{
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

		#region constructors

		public Log4NetContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Log4NetContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Log4NetContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Log4NetContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}

		#endregion constructors

		#region tables


		public System.Data.Linq.Table<Log> Log
		{
			get
			{
				return this.GetTable<Log>();
			}
		}



		#endregion tables

		#region Binary Column Load and Update Methods 



		#endregion Binary Column Load and Update Methods 

		#region GetAscendant... and GetDescendant... Methods 



		#endregion GetAscendant... and GetDescendant... Methods 

		#region Extensibility Method Definitions
	    partial void OnCreated();


		partial void InsertLog(Log instance);
		partial void UpdateLog(Log instance);
		partial void DeleteLog(Log instance);


		#endregion Extensibility Method Definitions

	}
#region Type of dbo.Log, the Member is Log, the type is Log

	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Log")]
	public partial class Log : INotifyPropertyChanging, INotifyPropertyChanged
	{

		#region constructors

		public Log()
		{

			#region initialize fields for Association, FK


			#endregion initialize fields for Association, FK


			#region initialize fields for Association, not a FK



			#endregion initialize fields for Association, not a FK

			OnCreated();
		}

		#endregion constructors

		#region INotifyPropertyChanging or INotifyPropertyChanged related

		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion INotifyPropertyChanging or INotifyPropertyChanged related


		#region event handler attach and detach, not a FK



		#endregion event handler attach and detach, not a FK

		#region fields, storage for Properties


		private System.Int64 _Id;


		private System.DateTime _Date;


		private System.String _Thread;


		private System.String _Level;


		private System.String _Logger;


		private System.String _Message;


		private System.String _Exception;



		#endregion fields, storage for Properties

		#region fields, storage for Association, FK



		#endregion fields, storage for Association, FK


		#region fields, storage for Association, not a FK



		#endregion fields, storage for Association, not a FK

		#region Properties


		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.OnInsert)]
		public System.Int64 Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}



		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime NOT NULL", IsPrimaryKey=false, IsDbGenerated=false)]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}



		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Thread", DbType="VarChar(255) NOT NULL", IsPrimaryKey=false, IsDbGenerated=false)]
		public System.String Thread
		{
			get
			{
				return this._Thread;
			}
			set
			{
				if ((this._Thread != value))
				{
					this.OnThreadChanging(value);
					this.SendPropertyChanging();
					this._Thread = value;
					this.SendPropertyChanged("Thread");
					this.OnThreadChanged();
				}
			}
		}



		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Level", DbType="VarChar(50) NOT NULL", IsPrimaryKey=false, IsDbGenerated=false)]
		public System.String Level
		{
			get
			{
				return this._Level;
			}
			set
			{
				if ((this._Level != value))
				{
					this.OnLevelChanging(value);
					this.SendPropertyChanging();
					this._Level = value;
					this.SendPropertyChanged("Level");
					this.OnLevelChanged();
				}
			}
		}



		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Logger", DbType="VarChar(255) NOT NULL", IsPrimaryKey=false, IsDbGenerated=false)]
		public System.String Logger
		{
			get
			{
				return this._Logger;
			}
			set
			{
				if ((this._Logger != value))
				{
					this.OnLoggerChanging(value);
					this.SendPropertyChanging();
					this._Logger = value;
					this.SendPropertyChanged("Logger");
					this.OnLoggerChanged();
				}
			}
		}



		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="VarChar(4000) NOT NULL", IsPrimaryKey=false, IsDbGenerated=false)]
		public System.String Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this.OnMessageChanging(value);
					this.SendPropertyChanging();
					this._Message = value;
					this.SendPropertyChanged("Message");
					this.OnMessageChanged();
				}
			}
		}



		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Exception", DbType="VarChar(2000) NULL", IsPrimaryKey=false, IsDbGenerated=false)]
		public System.String Exception
		{
			get
			{
				return this._Exception;
			}
			set
			{
				if ((this._Exception != value))
				{
					this.OnExceptionChanging(value);
					this.SendPropertyChanging();
					this._Exception = value;
					this.SendPropertyChanged("Exception");
					this.OnExceptionChanged();
				}
			}
		}



		#endregion Properties


		#region Properties for Association, FK



		#endregion Properties for Association, FK


		#region Properties for Association, not a FK



		#endregion Properties for Association, not a FK

		#region Extensibility Method Definitions
		partial void OnLoaded();
		partial void OnValidate(System.Data.Linq.ChangeAction action);
		partial void OnCreated();


		partial void OnIdChanging(System.Int64 value);
		partial void OnIdChanged();


		partial void OnDateChanging(System.DateTime value);
		partial void OnDateChanged();


		partial void OnThreadChanging(System.String value);
		partial void OnThreadChanged();


		partial void OnLevelChanging(System.String value);
		partial void OnLevelChanged();


		partial void OnLoggerChanging(System.String value);
		partial void OnLoggerChanged();


		partial void OnMessageChanging(System.String value);
		partial void OnMessageChanged();


		partial void OnExceptionChanging(System.String value);
		partial void OnExceptionChanged();


		#endregion Extensibility Method Definitions
	}

	#endregion Type of dbo.Log, the Member is Log, the type is Log




}
#pragma warning restore 1591