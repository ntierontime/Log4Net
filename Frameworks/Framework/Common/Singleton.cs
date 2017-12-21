using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    /// <summary>
    /// http://www.codeproject.com/Articles/11111/Generic-Singleton-Provider
    /// </summary>
    /// <typeparam name="T">a class</typeparam>
    public class Singleton<T> where T : new()
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static T Instance
        {
            get
            {
                return SingletonCreator.instance;
            }
        }

        /// <summary>
        /// To instantiate the type 'T'.
        /// </summary>
        public class SingletonCreator
        {
            /// <summary>
            /// Initializes the <see cref="Singleton&lt;T&gt;.SingletonCreator"/> class.
            /// </summary>
            static SingletonCreator()
            {
            }
            /// <summary>
            /// return an instance of T
            /// </summary>
            internal static readonly T instance = new T();
        }
    }
}

