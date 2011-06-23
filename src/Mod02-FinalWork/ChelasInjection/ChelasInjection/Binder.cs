using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ChelasInjection.Attributes;

namespace ChelasInjection
{
    public delegate object ResolverHandler(Binder sender, Type t);

    public abstract partial class Binder
    {
        private readonly Dictionary<TypeKey, ITypeConfiguration> _configuration = new Dictionary<TypeKey, ITypeConfiguration>();
        internal Dictionary<TypeKey, ITypeConfiguration> Configuration
        {
            get { return _configuration; }
        }

        internal TypeConfiguration CurrentConfiguration { get; set; }
        
        public void Configure()
        {
            InternalConfigure();
            EndLastBind();

        }

        protected abstract void InternalConfigure();


        public event ResolverHandler CustomResolver;

        public ITypeBinder<Target> Bind<Source, Target>()
        {
            var sourceType = typeof (Source);
            var targetType = typeof (Target);

            EndLastBind();

            this.CurrentConfiguration =
                new TypeConfiguration(sourceType, targetType);


            return new TypeBinder<Target>(this);
        }

        private void EndLastBind()
        {
            
            if (this.CurrentConfiguration != null)
            {
                AddConfiguration(this.CurrentConfiguration);
            }
        }

        private void AddConfiguration(ITypeConfiguration config)
        {
            var typeKey = new TypeKey(config.Source, config.ArgumentType);

            if (Configuration.ContainsKey(typeKey))
                Configuration[typeKey] = config;
            else
                Configuration.Add(typeKey, config);

            if (config.Constructor == null)
                FindConstructor(config);
        }

        private void FindConstructor(ITypeConfiguration configuration)
        {
            configuration.ConstructorType = ConstructorType.Default;

            configuration.Constructor =
                configuration.Target.GetConstructors().Where(
                    c =>
                    c.GetCustomAttributes(false)
                        .Where(a => a.GetType().Equals(typeof(DefaultConstructorAttribute))).FirstOrDefault() != null)
                    .FirstOrDefault();

            if (configuration.Constructor == null)
            {

                var availableConstructors = configuration.Target.GetConstructors()
                    .Where(constructorInfo => constructorInfo.GetParameters()
                                                  .All(p => TargetTypeIsConfigured(new TypeKey(p.ParameterType)))).
                    ToArray();

                //default ctor with max parameters
                configuration.Constructor =
                    availableConstructors.Where(c => c.GetParameters().Length ==
                                                     availableConstructors.Max(
                                                         x => x.GetParameters().Length))
                        .FirstOrDefault();

                if (configuration.Constructor == null)
                {
                    configuration.Constructor = configuration.Target.GetConstructors().First();

                    if (configuration.Constructor == null)
                        throw new NotImplementedException("CANNOT FIND CONSTRUCTOR");
                }
            }
        }

        private bool TargetTypeIsConfigured(TypeKey targetType)
        {
            if (_configuration.ContainsKey(targetType))
                return true;
            if (_configuration.Values.FirstOrDefault(c => c.Target == targetType.Type) != null)
                return true;

            return false;
        }

        public ITypeBinder<Source> Bind<Source>()
        {
            return this.Bind<Source, Source>();
        }


        internal KeyValuePair<ResolverHandler, object> CustomResolve(Type type)
        {
            ResolverHandler del = null;
            object obj = null;

            CustomResolver
                .GetInvocationList()
                .FirstOrDefault(d =>
                                    {
                                        del = (ResolverHandler)d;
                                        obj = del(this, type);
                                        return obj != null;
                                    });

            return new KeyValuePair<ResolverHandler, object>(del, obj);
            //.Select(
            //@delegate => new KeyValuePair<ResolverHandler, object>(
            //    ((ResolverHandler)@delegate),
            //    ((ResolverHandler)@delegate)(this, type)
            //))
            //.FirstOrDefault(objRet => objRet.Value != null);
        }

        internal bool IsSingleton(TypeKey type)
        {
            if (_configuration.ContainsKey(type))
            {
                if (_configuration[type].ActivationType == ActivationType.Singleton)
                    return true;
            }
            return false;
        }

        internal bool IsConfigured(TypeKey type)
        {
            return (_configuration.ContainsKey(type));
        }

        internal Action<object> GetInitializeObjectWith(TypeKey type)
        {
            if (_configuration.ContainsKey(type))
            {
                return _configuration[type].InitializationFunc;
            }
            return null;
        }
    }
}