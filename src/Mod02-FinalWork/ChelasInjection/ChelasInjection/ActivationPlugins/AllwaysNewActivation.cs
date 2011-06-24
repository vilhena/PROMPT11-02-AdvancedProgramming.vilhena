using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ChelasInjection.ActivationPlugins
{
    class AllwaysNewActivation:IActivationPlugin
    {
        public object GetInstance(TypeKey objectType)
        {
            return null;
        }

        public void NewInstance(TypeKey key, object obj)
        {
        }

        public void BeginRequest()
        {
            
        }

        public void EndRequest()
        {
            
        }

        public ExpressionType GetConstructorExpression()
        {
            return ExpressionType.New;
        }
    }
}
