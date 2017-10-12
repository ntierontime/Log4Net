using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Log4Net.EntityContracts
{
    /// <summary>
    /// provides common methods/actions/stubs on an identifier of an entity.
    /// </summary>
    public static partial class ILogIdentifierHelper
    {

        #region Create new Identifier instance from Framework.NameValueCollection

        /// <summary>
        /// Creates the specified input.
        /// </summary>
        /// <typeparam name="T">type inherit from <see cref="ILogIdentifier"/></typeparam>
        /// <param name="input">The input.</param>
        /// <returns>a new instance</returns>
        public static T Create<T>(Framework.NameValueCollection input)
            where T : class, ILogIdentifier, new()
        {
            try
            {
                T _retval = new T();
                _retval.Id = System.Int64.Parse(input["Id"]);
                return _retval;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Creates the specified input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static T Create<T>(string input)
            where T : class, ILogIdentifier, new()
        {
            try
            {
                string[] _SplitInputValue = input.Split(";".ToCharArray());
                T _retval = new T();
                int _Count = 0;
                _retval.Id = System.Int64.Parse(_SplitInputValue[_Count++]);
                return _retval;
            }
            catch
            {
                return null;
            }
        }

        #endregion Create new Identifier instance from System.Collections.Specialized.NameValueCollection

        #region Copy<...>(...), Equals<...>(...), Clone<...>(...), ToString<...>(...),

        /// <summary>
        /// Copies the specified property from source.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public static void Copy<T1, T2>(T1 from, T2 to)
            where T1 : ILogIdentifier
            where T2 : ILogIdentifier
        {

            to.Id = from.Id;

        }

        /// <summary>
        /// Equalses the specified from.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <returns>true if with same values, otherwise false</returns>
        public static bool Equals<T1, T2>(T1 from, T2 to)
            where T1 : ILogIdentifier
            where T2 : ILogIdentifier
        {
            bool _retval = true;

            _retval = _retval && to.Id == from.Id;

            return _retval;
        }

        /// <summary>
        /// Clones the specified from.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="from">From.</param>
        /// <returns>a new instance</returns>
        public static T2 Clone<T1, T2>(T1 from)
            where T1 : ILogIdentifier
            where T2 : ILogIdentifier, new()
        {
            T2 _retval = new T2();
            Copy<T1, T2>(from, _retval);
            return _retval;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <typeparam name="T">type inherit from <see cref="ILogIdentifier"/></typeparam>
        /// <param name="input">The input.</param>
        /// <returns> A <see cref="System.String"/> that represents this instance.</returns>
        public static string ToString<T>(T input)
            where T : ILogIdentifier
        {
            string _Format = "Id:{0};";
            return string.Format(_Format, input.Id);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public static string ToString(System.Int64 id)
        {
            string _Format = "Id:{0}";
            return string.Format(_Format, id);
        }

        #endregion Copy<...>(...), Equals<...>(...), Clone<...>(...), ToString<...>(...),

        #region CopyCollection<...>(...), CloneCollection<...>(...)

        /// <summary>
        /// Copies the collection.
        /// </summary>
        /// <typeparam name="T1Collection">The type of the 1 collection.</typeparam>
        /// <typeparam name="T2Collection">The type of the 2 collection.</typeparam>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public static void CopyCollection<T1Collection, T2Collection, T1, T2>(T1Collection from, T2Collection to)
            where T1Collection : IEnumerable<T1>
            where T2Collection : IList<T2>
            where T1 : ILogIdentifier
            where T2 : ILogIdentifier, new()
        {
            foreach (T1 _Item in from)
            {
                T2 _Cloned = Clone<T1, T2>(_Item);
                to.Add(_Cloned);
            }
        }

        /// <summary>
        /// Clones the collection.
        /// </summary>
        /// <typeparam name="T1Collection">The type of the 1 collection.</typeparam>
        /// <typeparam name="T2Collection">The type of the 2 collection.</typeparam>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="from">From.</param>
        /// <returns>a new instance of entity collection</returns>
        public static T2Collection CloneCollection<T1Collection, T2Collection, T1, T2>(T1Collection from)
            where T1Collection : IEnumerable<T1>
            where T2Collection : IList<T2>, new()
            where T1 : ILogIdentifier
            where T2 : ILogIdentifier, new()
        {
            T2Collection _retval = new T2Collection();
            CopyCollection<T1Collection, T2Collection, T1, T2>(from, _retval);
            return _retval;
        }

        #endregion CopyCollection<...>(...), CloneCollection<...>(...)
    }
}