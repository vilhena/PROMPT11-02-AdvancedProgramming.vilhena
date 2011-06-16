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

        public TypeConfiguration(Type source, Type target)
        {
            this.Source = source;
            this.Target = target;
        }

        public Func<object> ConstructorValues { get; set; }

        public ConstructorType ConstructorType { get; set; }

        public Action<object> InitializationFunc { get; set; }

        public ConstructorInfo Constructor { get; set; }
    }
}
