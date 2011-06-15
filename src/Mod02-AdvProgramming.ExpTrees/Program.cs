using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Mod02_AdvProgramming.ExpTrees
{
    // Helper extension methods to simplify the code
    // These helper methods are not safe - they throw exceptions
    // whenever applied on nodes that are not of type BinaryExpression
    public static class TreeHelper
    {
        public static Expression Left(this Expression exp)
        {
            return (exp as BinaryExpression).Left;
        }
        public static Expression Right(this Expression exp)
        {
            return (exp as BinaryExpression).Right;
        }
    }
    class Program
    {

        static void DemoCreatingExpressionTrees()
        {
            Func<double, double, double> triangleArea = (b, h) => b * h / 2;
            Console.WriteLine("*** Delegate ***");
            Console.WriteLine("ToString: {0}", triangleArea);
            Console.WriteLine("Value: {0}", triangleArea(7, 12));
            Expression<Func<double, double, double>> TriangleAreaExp = (b, h) => b * h / 2;
            Console.WriteLine("*** Expression tree ***");
            Console.WriteLine("ToString: {0}", TriangleAreaExp);
            Console.WriteLine("Value: {0}", TriangleAreaExp.Compile()(7, 12));
        }

        static int Double(int n)
        {
            return n * 2;
        }

        static void DemoExpressionTreesImutability()
        {
            Imutability();
            ReplaceLevel2();
            ReplaceLevel3();
        }

        private static void Imutability()
        {
            Expression<Func<int, int>> Formula = (n) => (n * 2 + 1) * 4;
            Console.WriteLine(Formula.ToString());
            BinaryExpression top = Formula.Body as BinaryExpression;
            ConstantExpression constant = top.Right as ConstantExpression;
            Console.WriteLine(constant.Value);
            //constant.Value = 5; // Compiler error - Value is a read-only property
        }

        static void ReplaceLevel2()
        {
            Expression<Func<int, int>> Formula = (n) => (n * 2 + 1) * 4;
            // Replace 4 with 5
            // Results in
            // (n * 2 + 1) * 5
            Expression top = Formula.Body;
            ConstantExpression newRight = Expression.Constant(5);
            Expression newTree = Expression.MakeBinary(top.NodeType, top.Left(), newRight);

            Console.WriteLine("Original tree: {0}", top);
            Console.WriteLine("Modified tree: {0}", newTree);

        }

        static void ReplaceLevel3()
        {
            Expression<Func<int, int>> Formula = (n) => (n * 2 + 1) * 4;
            // Replace 1 with 3
            // Results in
            // (n * 2 + 3) * 4
            Expression top = Formula.Body;
            ConstantExpression newConstantSum = Expression.Constant(3);
            Expression newSum = Expression.MakeBinary(top.Left().NodeType, top.Left().Left(), newConstantSum);
            Expression newTree = Expression.MakeBinary(top.NodeType, newSum, top.Right());
            Console.WriteLine("Original tree: {0}", top.ToString());
            Console.WriteLine("Modified tree: {0}", newTree.ToString());
        }


        static void DemoExpressionVisitor()
        {
            Expression<Func<int, int>> Formula = (n) => 1 + Double(n * (n % 2 == 0 ? -1 : 1));
            Console.WriteLine(Formula.ToString());
            DisplayVisitor visitor = new DisplayVisitor();
            visitor.Display(Formula);
            Expression<Func<double, double, double>> exp = ((b, h) => b * h / 2);
            visitor.Display(exp);
        }


        static void Main(string[] args)
        {
            // 1 - Creating Expression Trees
            //DemoCreatingExpressionTrees();

            // 2- Expression Trees Imutability
            //DemoExpressionTreesImutability();


            // 3- DisplayExpressionVisitor
            DemoExpressionVisitor();
        }
    }
}
