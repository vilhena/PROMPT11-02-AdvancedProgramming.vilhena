using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ChelasInjection
{
    internal class TypeKey
    {
        private readonly Type _type;
        private readonly Type _attributeType;

        public bool Equals(TypeKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._type, _type) && Equals(other._attributeType, _attributeType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TypeKey)) return false;
            return Equals((TypeKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_type.GetHashCode()*397) ^ (_attributeType != null ? _attributeType.GetHashCode() : 0);
            }
        }

        public TypeKey(Type type, Type attributeType)
        {
            _type = type;
            _attributeType = attributeType;
        }

        public TypeKey(Type type)
        {
            _type = type;
            _attributeType = null;
        }

        public Type Type { get { return _type; } }
        public Type AttributeType { get { return _attributeType; } }
    }

    interface ITypeConfiguration
    {
        ActivationType ActivationType { get; set; }
        Type Source { get; }
        Type Target { get; }
        List<Type> ConstructorArguments { get; set; }

        //Dictionary<Type, ITypeConfiguration> ArgumentsConfiguration { get; set; }
        Type ArgumentType { get; set; }

        Func<object> ConstructorValues { get; set; }


        ConstructorType ConstructorType { get; set; }

        Action<object> InitializationFunc { get; set; }

        ConstructorInfo Constructor { get; set; }
    }
}
