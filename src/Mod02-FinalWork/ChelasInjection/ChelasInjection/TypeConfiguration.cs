using System;
using System.Collections.Generic;
using System.Reflection;
using ChelasInjection.ActivationPlugins;

namespace ChelasInjection
{
    internal class TypeConfiguration : ITypeConfiguration
    {
        private Dictionary<Type, ITypeConfiguration> _argumentsConfiguration =
            new Dictionary<Type, ITypeConfiguration>();

        public TypeConfiguration(Type source, Type target)
        {
            IsArgumentDependent = false;
            Source = source;
            Target = target;
        }

        public Dictionary<Type, ITypeConfiguration> ArgumentsConfiguration
        {
            get { return _argumentsConfiguration; }
            set { _argumentsConfiguration = value; }
        }

        public bool IsArgumentDependent { get; set; }

        #region ITypeConfiguration Members

        public Type Source { get; private set; }
        public Type Target { get; private set; }

        //public ActivationType ActivationType { get; set; }

        public List<Type> ConstructorArguments { get; set; }

        public Func<object> ConstructorValues { get; set; }

        public ConstructorType ConstructorType { get; set; }

        public Action<object> InitializationFunc { get; set; }

        public ConstructorInfo Constructor { get; set; }

        public Type ArgumentType { get; set; }

        #endregion


        public IActivationPlugin ActivationPlugin { get; set; }
    }
}