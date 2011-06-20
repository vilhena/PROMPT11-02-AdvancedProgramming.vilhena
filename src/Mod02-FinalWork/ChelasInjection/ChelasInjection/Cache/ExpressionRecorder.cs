using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ChelasInjection.Cache
{
    internal class ExpressionRecorder
    {
        private Queue<Expression> _executionQueue = new Queue<Expression>();
        private Dictionary<object, Expression> _objectVariables = new Dictionary<object, Expression>();
        private int _varNameCount = 0;

        private string NewVariable { get { return "local" + ++_varNameCount; } }
        private string CurrentVariable { get { return "local" + _varNameCount; } }


        public void Start()
        {
            _varNameCount = 0;
            _executionQueue = new Queue<Expression>();
            _objectVariables = new Dictionary<object, Expression>();

        }

        public void Stop(){}

        public LambdaExpression Result()
        {
            if (_executionQueue.Count == 0)
                return null;

            var listLocal = new List<ParameterExpression>();
            var listAssigns = new List<Expression>();

            while (_executionQueue.Count > 0)
            {
                var ex = _executionQueue.Dequeue();

                if (ex.NodeType == ExpressionType.Assign)
                {
                    var assign = ex as BinaryExpression;
                    listLocal.Add((ParameterExpression) assign.Left);
                }
                listAssigns.Add(ex);   
            }

            listAssigns.Add(listLocal.Last());
            

            var block = Expression.Block(
                listLocal.ToArray(),
                listAssigns.ToArray()
                );

            return Expression.Lambda<Func<object>>(
                block
                );

        }


        public object ActivatorCreateInstance(Type type, bool isSingleton)
        {
            var newObj = Activator.CreateInstance(type);

            var newVar = Expression.Variable(type, NewVariable);
            Expression ex;

            if (isSingleton)
                ex = Expression.Constant(newObj);
            else
                ex = Expression.New(type);
            
            _objectVariables.Add(newObj,newVar);
            _executionQueue.Enqueue(Expression.Assign(newVar, ex));

            return newObj;
        }

        public object ActivatorCreateInstance(Type type, object[] args, bool  isSingleton)
        {
            var newObj = Activator.CreateInstance(type, args);

            var ctor = type.GetConstructor(args.Select(o => o.GetType()).ToArray());

            var newVar = Expression.Variable(type, NewVariable);
            
            Expression ex;

            if (isSingleton)
                ex = Expression.Constant(newObj);
            else
                ex = Expression.New(ctor,
                                   args.Select(FindVariableName));
            

            _objectVariables.Add(newObj, newVar);
            _executionQueue.Enqueue(Expression.Assign(newVar, ex));

            return newObj;
        }

        private Expression FindVariableName(object o)
        {
            if (_objectVariables.ContainsKey(o))
                return _objectVariables[o];
            else
            {
                return Expression.Constant(o);
            }
        }

        public object PropertyGetValue(PropertyInfo pinfo, object obj)
        {
            var pValue = pinfo.GetValue(obj, new object[] {});

            var newVar = Expression.Variable(pinfo.PropertyType, NewVariable);
            var ex =
                Expression.Property(_objectVariables[obj], pinfo);


            _objectVariables.Add(pValue, newVar);
            _executionQueue.Enqueue(Expression.Assign(newVar, ex));

            return pValue;
        }

        internal object GetConstructorValues(Func<object> func)
        {
            var retType = func();

            if (!_objectVariables.ContainsKey(retType))
            {
                var newVar = Expression.Variable(typeof(object), NewVariable);
                var ex =
                    Expression.Call(func.Method);

                _objectVariables.Add(retType, newVar);
                _executionQueue.Enqueue(Expression.Assign(newVar, ex));
            }
            return retType;
        }

        internal void InitializeObjectWith(Action<object> initialization, object newObj)
        {
            //initialize object
            initialization(newObj);

            var ex = Expression.Invoke(Expression.Constant(initialization),
                                     _objectVariables[newObj]);
            
            _executionQueue.Enqueue(ex);
        }

        internal void CustomResolve(ResolverHandler resolverHandler, object obj, Binder binder, Type targetType)
        {
            //initialize object


            var newVar = Expression.Variable(obj.GetType(), NewVariable);
            var del = Expression.Invoke(Expression.Constant(resolverHandler)
                                        , new Expression[]
                                              {
                                                  Expression.Constant(binder),
                                                  Expression.Constant(targetType)
                                              });

            var ex = Expression.Assign(newVar, Expression.Convert(del, obj.GetType()));

            _objectVariables.Add(obj, newVar);

            _executionQueue.Enqueue(ex);
        }
    }
}
