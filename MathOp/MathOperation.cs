using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOp
{
    class MathOperation
    {
        private static readonly char[] _validOperators = { '+', '-','*', '/', '%' };
        public static MathOperation ReadFromConsole()
        {
            Console.Write("Please enter the left operand: ");
            string sLeft = Console.ReadLine();
            if (!double.TryParse(sLeft, out double leftOp)) return null;
            Console.Write("Please ente the Operator: ");
            string sOp = Console.ReadLine();
            if (sOp.Length != 1 || !_validOperators.Contains(sOp[0])) return null;
            Console.Write("Please enter the right operand: ");
            string sRight = Console.ReadLine();
            if (!double.TryParse(sRight, out double rightOp)) return null;
            return new MathOperation
            {
                LeftOperand = leftOp,
                Operator = sOp[0],
                RightOperand = rightOp
            };
        }

        public double LeftOperand { get; private set; }
        public double RightOperand { get; private set; }
        public char Operator { get; private set; }

        public double Result
        {
            get
            {
                switch (Operator)
                {
                    case '+': return LeftOperand + RightOperand;
                    case '-': return LeftOperand - RightOperand;
                    case '*': return LeftOperand * RightOperand;
                    case '/': return LeftOperand / RightOperand;
                    case '%': return LeftOperand % RightOperand;
                }
                throw new Exception($"Unknown Operator: {Operator}");
            }
        }
        public override string ToString()
        {
            return $"{LeftOperand: F3} {Operator} {RightOperand: F3} = {Result: F3}";
        }
    }
}