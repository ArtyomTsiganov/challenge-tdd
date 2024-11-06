using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public static class PostfixCalculator
    {
        public static string Calculate(string postfixExpression)
        {
            if (postfixExpression == null) throw new FormatException();
            if (postfixExpression == "") return "0";
            var postfix = postfixExpression.Split(' ');
            var stack = new Stack<LongComplex>();
            foreach (var sym in postfix)
            {
                if (sym == "+")
                {   
                    if (stack.Count < 2) throw new FormatException();
                    var x = stack.Pop();
                    var y = stack.Pop();
                    stack.Push(LongComplex.Add(y, x));
                }
                else if (sym == "-")
                {
                    if (stack.Count < 2) throw new FormatException();
                    var x = stack.Pop();
                    var y = stack.Pop();
                    stack.Push(LongComplex.Subtract(y, x));
                }
                else if (sym == "*")
                {
                    if (stack.Count < 2) throw new FormatException();
                    var x = stack.Pop();
                    var y = stack.Pop();
                    stack.Push(LongComplex.Multiply(y, x));
                }
                else
                {
                    stack.Push(LongComplex.Parse(sym));
                }
            }
            var result = stack.Pop().ToString();
            if (stack.Count > 0) throw new FormatException();
            return result;
        }
    }
}
