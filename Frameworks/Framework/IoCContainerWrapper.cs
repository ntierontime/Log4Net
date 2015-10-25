using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Framework
{
    /// <summary>
    /// IoCContainerWrapper, now using self developed Dependency Injector Container
    /// </summary>
	public class IoCContainerWrapper
    {
		/// <summary>
        /// Initializes a new instance of the <see cref="IoCContainerWrapper"/> class.
        /// </summary>
        public IoCContainerWrapper()
        {
            this.IoCContainer = new DIContainer();
        }

        /// <summary>
        /// Gets or sets the IoCContainer.
        /// </summary>
        /// <value>
        /// The IoCContainer
        /// </value>
        public DIContainer IoCContainer { get; set; }
    }

    public class DuplicateRegistrationException : Exception
    {
        public DuplicateRegistrationException() { }
        public DuplicateRegistrationException(string message) : base(message) { }
        public DuplicateRegistrationException(string message, Exception inner) : base(message, inner) { }
    }
    public interface IDIContainer
    {
        void Register<TIntf, TClass>()
            where TIntf : class
            where TClass : TIntf;
        TIntf Resolve<TIntf>() where TIntf : class;
        void RegisterInstance<TIntf>(TIntf instance);
    }

    public class DIContainer : IDIContainer
    {

        Dictionary<Type, Type> m_TypeRegistrations;
        Dictionary<Type, object> m_InstanceRegistrations;

        public DIContainer()
        {
            m_TypeRegistrations = new Dictionary<Type, Type>();
            m_InstanceRegistrations = new Dictionary<Type, object>();
        }

        #region IDIContainer Members

        public void Register<TIntf, TClass>()
            where TIntf : class
            where TClass : TIntf
        {
            if (DoesRegistrationExist<TIntf>())
                throw new DuplicateRegistrationException("Can only contain one registration per type");
            m_TypeRegistrations.Add(typeof(TIntf), typeof(TClass));
        }

        public TIntf Resolve<TIntf>() where TIntf : class
        {
            return Resolve(typeof(TIntf)) as TIntf;
        }

        private object Resolve(Type type)
        {
            if (!m_TypeRegistrations.ContainsKey(type))
            {
                if (!m_InstanceRegistrations.ContainsKey(type))
                    throw new NotSupportedException("Cannot find registration for type " + type.FullName + ".");
                else
                    return m_InstanceRegistrations[type];
            }
            else
            {
                //var createdType = m_TypeRegistrations[type];

                //ConstructorInfo[] constructors = createdType.GetConstructors();
                //ConstructorInfo mostSpecificConstructor = null;
                //foreach (var c in constructors)
                //{
                //    if (mostSpecificConstructor == null || mostSpecificConstructor.GetParameters().Length < c.GetParameters().Length)
                //    {
                //        mostSpecificConstructor = c;
                //    }
                //}

                //List<object> constructorParameters = new List<object>();
                //foreach (var a in mostSpecificConstructor.GetParameters())
                //{
                //    constructorParameters.Add(Resolve(a.ParameterType));
                //}

                //return Activator.CreateInstance(createdType, constructorParameters.ToArray());

                var createdType = m_TypeRegistrations[type];
                return Activator.CreateInstance(createdType, null);
            }
        }

        private bool DoesRegistrationExist<T>()
        {
            return m_InstanceRegistrations.ContainsKey(typeof(T)) || m_TypeRegistrations.ContainsKey(typeof(T));
        }

        public void RegisterInstance<TIntf>(TIntf instance)
        {
            if (DoesRegistrationExist<TIntf>())
            {
                throw new DuplicateRegistrationException("Can only contain one registration per type");
            }
            m_InstanceRegistrations.Add(typeof(TIntf), instance);
        }

        public void Clear()
        {
            if (this.m_InstanceRegistrations != null)
            {
                this.m_InstanceRegistrations.Clear();
            }
            if (this.m_TypeRegistrations != null)
            {
                this.m_TypeRegistrations.Clear();
            }
        }
        #endregion
    }

	/// <summary>
    /// Singleton of <see cref="IoCContainerWrapper"/>
    /// </summary>
    public class IoCContainerWrapperSingleton : Singleton<IoCContainerWrapper>
    {
    }
}