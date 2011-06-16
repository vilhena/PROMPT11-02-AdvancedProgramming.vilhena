using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChelasInjection
{
    interface ITypeConfiguration
    {
        ActivationType ActivationType { get; set; }
        Type Source { get; }
        Type Target { get; }
        List<Type> ConstructorArguments { get; set; }
        Func<object> ConstructorValues { get; set; }

        ConstructorType ConstructorType { get; set; }

        Action<object> InitializationFunc { get; set; }

        ConstructorInfo Constructor { get; set; }
    }
}
