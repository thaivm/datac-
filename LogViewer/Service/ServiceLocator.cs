﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LogViewer.Service
{
	/// <summary>
	/// A very simple service locator.
	/// </summary>
	static class ServiceLocator
	{
		public static Dictionary<Type, ServiceInfo> services = new Dictionary<Type, ServiceInfo>();


		/// <summary>
		/// Registers a service.
		/// </summary>
		public static void Register<TInterface, TImplemention>() where TImplemention : TInterface
		{
			Register<TInterface, TImplemention>(false);
		}

        public static void UnRegister<TInterface, TImplemention>() where TImplemention : TInterface
        {
            UnRegister<TInterface, TImplemention>(false);
        }

		/// <summary>
		/// Registers a service as a singleton.
		/// </summary>
		public static void RegisterSingleton<TInterface, TImplemention>() where TImplemention : TInterface
		{
			Register<TInterface, TImplemention>(true);
		}
        /// <summary>
        /// Registers a service as a singleton.
        /// </summary>
        public static void UnRegisterSingleton<TInterface, TImplemention>() where TImplemention : TInterface
        {
            UnRegister<TInterface, TImplemention>(true);
        }


		/// <summary>
		/// Resolves a service.
		/// </summary>
		public static TInterface Resolve<TInterface>()
		{
			return (TInterface)services[typeof(TInterface)].ServiceImplementation;
		}


		/// <summary>
		/// Registers a service.
		/// </summary>
		/// <param name="isSingleton">true if service is Singleton; otherwise false.</param>
        public static void Register<TInterface, TImplemention>(bool isSingleton) where TImplemention : TInterface
		{
		    services.Add(typeof(TInterface), new ServiceInfo(typeof(TImplemention), isSingleton));
		}

        /// <summary>
        /// Registers a service.
        /// </summary>
        /// <param name="isSingleton">true if service is Singleton; otherwise false.</param>
        public static void UnRegister<TInterface, TImplemention>(bool isSingleton) where TImplemention : TInterface
        {
            services.Remove(typeof(TInterface));
        }


		/// <summary>
		/// Class holding service information.
		/// </summary>
		public class ServiceInfo
		{
			protected Type serviceImplementationType;
			protected object serviceImplementation;
			protected bool isSingleton;


			/// <summary>
			/// Initializes a new instance of the <see cref="ServiceInfo"/> class.
			/// </summary>
			/// <param name="serviceImplementationType">Type of the service implementation.</param>
			/// <param name="isSingleton">Whether the service is a Singleton.</param>
			public ServiceInfo(Type serviceImplementationType, bool isSingleton)
			{
				this.serviceImplementationType = serviceImplementationType;
				this.isSingleton = isSingleton;
			}

			
			/// <summary>
			/// Gets the service implementation.
			/// </summary>
			public object ServiceImplementation
			{
				get
				{
					if (isSingleton)
					{
						if (serviceImplementation == null)
						{
							serviceImplementation = CreateInstance(serviceImplementationType);
						}

						return serviceImplementation;
					}
					else
					{
						return CreateInstance(serviceImplementationType);
					}
				}
			}


			/// <summary>
			/// Creates an instance of a specific type.
			/// </summary>
			/// <param name="type">The type of the instance to create.</param>
			protected static object CreateInstance(Type type)
			{
				if (services.ContainsKey(type))
				{
					return services[type].ServiceImplementation;
				}

				ConstructorInfo ctor = type.GetConstructors().First();

				var parameters =
					from parameter in ctor.GetParameters()
					select CreateInstance(parameter.ParameterType);

				return Activator.CreateInstance(type, parameters.ToArray());
			}
		}
	}
}
