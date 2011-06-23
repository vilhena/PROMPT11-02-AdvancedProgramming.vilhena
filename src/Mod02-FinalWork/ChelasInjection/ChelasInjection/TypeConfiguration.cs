using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChelasInjection
{
    internal class TypeConfiguration : ITypeConfiguration
    {
        public Type Source { get; private set; }
        public Type Target { get; private set; }

        public ActivationType ActivationType { get; set; }
        public List<Type> ConstructorArguments { get; set; }

        private Dictionary<Type, ITypeConfiguration> _argumentsConfiguration = new Dictionary<Type, ITypeConfiguration>();
        public Dictionary<Type, ITypeConfiguration> ArgumentsConfiguration
        {
            get { return _argumentsConfiguration; }
            set { _argumentsConfiguration = value; }
        }

        public TypeConfiguration(Type source, Type target)
        {
            IsArgumentDependent = false;
            this.Source = source;
            this.Target = target;
        }

        public Func<object> ConstructorValues { get; set; }

        public ConstructorType ConstructorType { get; set; }

        public Action<object> InitializationFunc { get; set; }

        public ConstructorInfo Constructor { get; set; }

        public bool IsArgumentDependent { get; set; }

        public Type ArgumentType { get; set; }
    }
}
