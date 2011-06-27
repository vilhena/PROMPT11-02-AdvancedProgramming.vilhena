using System;
using System.Collections.Generic;
using System.Linq;
using ChelasInjection.ActivationPlugins;

namespace ChelasInjection
{
    public delegate object ResolverHandler(Binder sender, Type t);

    public abstract partial class Binder
    {
        #region Properties And Fields
        private readonly Dictionary<TypeKey, ITypeConfiguration> _configuration =
            new Dictionary<TypeKey, ITypeConfiguration>();

        internal Dictionary<TypeKey, ITypeConfiguration> Configuration
        {
            get { return _configuration; }
        }

        internal TypeConfiguration CurrentConfiguration { get; set; }

        private IActivationPlugin _defaultActivation;

        #endregion

        public void Configure()
        {
            _defaultActivation = PerRequestActivation.Instance;
            InternalConfigure();
            EndLastBind();
        }

        protected abstract void InternalConfigure();

        public event ResolverHandler CustomResolver;

        public ITypeBinder<Target> Bind<Source, Target>()
        {
            EndLastBind();

            CurrentConfiguration =
                new TypeConfiguration(typeof(Source), typeof(Target));
            CurrentConfiguration.ActivationPlugin = _defaultActivation;

            return new TypeBinder<Target>(this);
        }

        public ITypeBinder<Source> Bind<Source>()
        {
            return Bind<Source, Source>();
        }

        #region Private Methods
        private void EndLastBind()
        {
            if (CurrentConfiguration != null)
            {
                AddConfiguration(CurrentConfiguration);
            }
        }


        private void AddConfiguration(ITypeConfiguration config)
        {
            var typeKey = new TypeKey(config.Source, config.ArgumentType);

            if (Configuration.ContainsKey(typeKey))
                Configuration[typeKey] = config;
            else
                Configuration.Add(typeKey, config);
        } 
        #endregion

        #region Internal Methods

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
        }

        internal bool IsConfigured(TypeKey type)
        {
            return (_configuration.ContainsKey(type));
        }

        internal Action<object> GetInitializeObjectWith(TypeKey type)
        {
            return _configuration.ContainsKey(type)
                       ? _configuration[type].InitializationFunc
                       : null;
        }

        internal IActivationPlugin ActivationPlugin(TypeKey type)
        {
            return IsConfigured(type)
                       ? _configuration[type].ActivationPlugin
                       : _defaultActivation;
        }

        #endregion
    }
}