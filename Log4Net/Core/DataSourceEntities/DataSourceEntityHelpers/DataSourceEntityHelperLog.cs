using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4Net.DataSourceEntities
{
    /// <summary>
    /// provides some common methods/actions/stubs. 
    /// </summary>
    public static class DataSourceEntityHelperLog
    {
		#region CreateEntity(...)

        /// <summary>
        /// Creates the entity.
        /// </summary>
        /// <returns>a new instance of <see cref="Log4Net.DataSourceEntities.Log"/></returns>
        public static Log4Net.DataSourceEntities.Log CreateEntity(
			System.Int64 id
			,System.DateTime date
			,System.String thread
			,System.String level
			,System.String logger
			,System.String message
			,System.String exception
			)
        {
            Log4Net.DataSourceEntities.Log _retval = new Log4Net.DataSourceEntities.Log(
				id
				,date
				,thread
				,level
				,logger
				,message
				,exception
				);
            return _retval;
        }

		#endregion CreateEntity(...)

		#region ValidateValueBeforeSaveToDatabase(...)

        /// <summary>
        /// Validates the value before save to database.
        /// </summary>
        /// <param name="item">The item.</param>
        public static void ValidateValueBeforeSaveToDatabase(Log4Net.DataSourceEntities.Log item)
        {
                    // DateTimePropertiesToMinValueOfDateTimeInSQL
                    if (item.Date < Framework.DateTimePeriodHelper.MinValueOfDateTimeInSQL)
                    {
	                   item.Date = Framework.DateTimePeriodHelper.MinValueOfDateTimeInSQL;
					}

        }


        /// <summary>
        /// Validates the value before save to database.
        /// </summary>
        /// <param name="input">The input.</param>
		public static void ValidateValueBeforeSaveToDatabase(Log4Net.DataSourceEntities.LogCollection input)
        {
			for(int i = 0; i < input.Count; i ++)
            {
				Log4Net.DataSourceEntities.Log _Item = input[i];
                ValidateValueBeforeSaveToDatabase(_Item);
            }
        }

		#endregion ValidateValueBeforeSaveToDatabase(...)

		#region AssignEnityReferenceIDs(...)

        /// <summary>
        /// Assigns the enity reference Ids.
        /// </summary>
        /// <param name="input">The input.</param>
		public static void AssignEnityReferenceIDs(Log4Net.DataSourceEntities.LogCollection input)
		{
			for(int i = 0; i < input.Count; i ++)
            {
				Log4Net.DataSourceEntities.Log _Item = input[i];

            }
		}

		#endregion AssignEnityReferenceIDs(...)


		#region CreateNameValuePair(...)

        /// <summary>
        /// Creates a new instance of view NameValuePair.
        /// </summary>
        /// <returns>an instance of <see cref="Framework.NameValuePair"/></returns>
        public static Framework.NameValuePair CreateNameValuePair(
System.String name, System.String value
			)
        {
            Framework.NameValuePair _retval = new Framework.NameValuePair();
				_retval.Name = name;
				_retval.Value = value;
            return _retval;
        }

		#endregion CreateNameValuePair(...)


		#region CreateKeyInformation(...)

        /// <summary>
        /// Creates a new instance of view KeyInformation.
        /// </summary>
        /// <returns>an instance of <see cref="Log4Net.DataSourceEntities.Log.KeyInformation"/></returns>
        public static Log4Net.DataSourceEntities.Log.KeyInformation CreateKeyInformation(
System.Int64 id
			)
        {
            Log4Net.DataSourceEntities.Log.KeyInformation _retval = new Log4Net.DataSourceEntities.Log.KeyInformation();
				_retval.Id = id;
            return _retval;
        }

		#endregion CreateKeyInformation(...)







	

	}

}