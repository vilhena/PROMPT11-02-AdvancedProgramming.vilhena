using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ChelasInjection.ActivationPlugins
{
    public interface IActivationPlugin
    {
        object GetInstance(TypeKey objectType);
        void NewInstance(TypeKey key, object obj);
        //TODO: Implement event
        void BeginRequest();
        void EndRequest();
        ExpressionType GetConstructorExpression();
    }
}
