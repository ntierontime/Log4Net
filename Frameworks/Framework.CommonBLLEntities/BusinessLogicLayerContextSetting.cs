using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.CommonBLLEntities
{
    /// <summary>
    /// System.Attribute for <see cref="BusinessLogicLayerContextSetting"/> 
    /// for DI/IoC purpose
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class BusinessLogicLayerContextSettingAttribute : Attribute
    {
		#region constructors

		/// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerContextSetting"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="typeOfBusinessLogicLayerContext">The type of business logic layer context.</param>
        /// <param name="typeOfLinqToSqlDataAccessLayerFactory">The type of linq to SQL data access layer factory.</param>
        public BusinessLogicLayerContextSettingAttribute(string key, Type typeOfBusinessLogicLayerContext, Type typeOfLinqToSqlDataAccessLayerFactory)
        {
            this.BusinessLogicLayerContextSetting = new BusinessLogicLayerContextSetting(key, null, typeOfBusinessLogicLayerContext, typeOfLinqToSqlDataAccessLayerFactory);
        }

		#endregion constructors

		#region properties

		/// <summary>
        /// Gets or sets the business logic layer context setting.
        /// </summary>
        /// <value>
        /// The business logic layer context setting.
        /// </value>
        BusinessLogicLayerContextSetting BusinessLogicLayerContextSetting { get; set; }

		#endregion properties

    }

    /// <summary>
    /// IoC for BusinessLogicLayerContext, now used in global.asax.cs
    /// </summary>
    public class BusinessLogicLayerContextSetting
    {
		#region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicLayerContextSetting"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="typeOfTargetUser">The type of target user.</param>
        /// <param name="typeOfBusinessLogicLayerContext">The type of business logic layer context.</param>
        /// <param name="typeOfLinqToSqlDataAccessLayerFactory">The type of linq to SQL data access layer factory.</param>
        public BusinessLogicLayerContextSetting(string key, Type typeOfTargetUser, Type typeOfBusinessLogicLayerContext, Type typeOfLinqToSqlDataAccessLayerFactory)
        {
            this.Key = key;
            this.TypeOfTargetUser = typeOfTargetUser;
            this.TypeOfBusinessLogicLayerContext = typeOfBusinessLogicLayerContext;
            this.TypeOfLinqToSqlDataAccessLayerFactory = typeOfLinqToSqlDataAccessLayerFactory;
        }

		#endregion constructors

		#region properties

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the type of target user.
        /// </summary>
        /// <value>
        /// The type of target user.
        /// </value>
        public Type TypeOfTargetUser { get; set; }

		/// <summary>
        /// Gets or sets the type of business logic layer context.
        /// </summary>
        /// <value>
        /// The type of business logic layer context.
        /// </value>
        public Type TypeOfBusinessLogicLayerContext { get; set; }

        /// <summary>
        /// Gets or sets the type of linq to SQL data access layer factory.
        /// </summary>
        /// <value>
        /// The type of linq to SQL data access layer factory.
        /// </value>
        public Type TypeOfLinqToSqlDataAccessLayerFactory { get; set; }
		
		#endregion properties
    }
}