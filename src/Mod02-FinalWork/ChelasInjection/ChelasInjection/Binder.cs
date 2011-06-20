using System;
using System.Collections.Generic;
using System.Linq;
using ChelasInjection.Attributes;

namespace ChelasInjection
{
    public delegate object ResolverHandler(Binder sender, Type t);

    public abstract partial class Binder
    {
        private readonly Dictionary<Type, ITypeConfiguration> _configuration = new Dictionary<Type, ITypeConfiguration>();
        internal Dictionary<Type, ITypeConfiguration> Configuration
        {
            get { return _configuration; }
        }

        internal TypeConfiguration CurrentConfiguration { get; set; }
        
        public void Configure()
        {
            InternalConfigure();
        }

        protected abstract void InternalConfigure();


        public event ResolverHandler CustomResolver;

        public ITypeBinder<Target> Bind<Source, Target>()
        {
            var sourceType = typeof (Source);
            var targetType = typeof (Target);

            if (!Configuration.ContainsKey(sourceType))
            {
                this.CurrentConfiguration =
                    new TypeConfiguration(sourceType, targetType);

                Configuration.Add(sourceType, this.CurrentConfiguration);

                this.CurrentConfiguration.ConstructorType = ConstructorType.Default;

                this.CurrentConfiguration.Constructor =
                    targetType.GetConstructors().Where(
                        c =>
                        c.GetCustomAttributes(false).Where(a => a.GetType().Equals(typeof (DefaultConstructorAttribute))) !=
                        null).FirstOrDefault();

                if (this.CurrentConfiguration.Constructor == null)
                {
                    //default ctor with max parameters
                    this.CurrentConfiguration.Constructor =
                        targetType.GetConstructors().Where(c => c.GetParameters().Length ==
                                                                     targetType.GetConstructors().Max(
                                                                         x => x.GetParameters().Length)).First();
                }

            }
            return new TypeBinder<Target>(this);
        }

        public ITypeBinder<Source> Bind<Source>()
        {
            return this.Bind<Source, Source>();
        }


        internal KeyValuePair<ResolverHandler, object> CustomResolve(Type type)
        {
            return CustomResolver
                .GetInvocationList()
                .Select(
                @delegate => new KeyValuePair<ResolverHandler, object>(
                    ((ResolverHandler)@delegate),
                    ((ResolverHandler)@delegate)(this, type)
                ))
                .FirstOrDefault(objRet => objRet.Value != null);
        }

        internal bool IsSingleton(Type type)
        {
            if (_configuration.ContainsKey(type))
            {
                if (_configuration[type].ActivationType == ActivationType.Singleton)
                    return true;
            }
            return false;
        }

        internal bool IsConfigured(Type type)
        {
            return (_configuration.ContainsKey(type));
        }

        internal Action<object> GetInitializeObjectWith(Type type)
        {
            if (_configuration.ContainsKey(type))
            {
                return _configuration[type].InitializationFunc;
            }
            return null;
        }
    }
}