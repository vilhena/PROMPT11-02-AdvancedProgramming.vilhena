using System;
using System.Linq.Expressions;

namespace Mod02_AdvProgramming.ExpTrees
{
    class DisplayVisitor : ExpressionVisitor
    {
        private int level = 0;
        public override Expression Visit(Expression exp)
        {
            if (exp != null)
            {
                for (int i = 0; i < level; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("{0} - {1}",
                exp.NodeType, exp.GetType().Name);
            }
            level++;
            Expression result = base.Visit(exp);
            level--;
            return result;
        }
        public void Display(Expression exp)
        {
            Console.WriteLine("===== DisplayVisitor.Display =====");
            this.Visit(exp);
        }
    }
}