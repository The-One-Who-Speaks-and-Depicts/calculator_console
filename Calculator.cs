using System;

namespace calculator_console
{
    public class Calculator
    {
        decimal? res = null;
        decimal first;
        decimal second;
        string op;
        enum LoopCondition
        {
            start,
            flow
        }
        static LoopCondition loopCondition = LoopCondition.start;

        static Calculator calculator;

        void Start()
        {
            first = Utils.DecimalParse("first");
            second = Utils.DecimalParse("second");                        
            op = Utils.OperationParse();  
            res = Operation(first, second, op);
        }

        void Flow()
        {
            Console.WriteLine($"Current result is {res.ToString()}");
            first = (decimal) res;
            second = Utils.DecimalParse("subsequent");
            op = Utils.OperationParse();                        
            res = Operation(first, second, op);
            if (res == null)
            {
                loopCondition = LoopCondition.start;
            }
        }

        
        static decimal? Operation(decimal first, decimal second, string op)
        {                      
            switch (op)
            {
                case "+":
                    return first + second;
                case "*":
                    return first * second;
                case "-":
                    return first - second;
                case "/":
                    try 
                    {
                        return first/second;
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Cannot divide by zero!");
                        return first;
                    }
                    case "C":
                    default:
                        return null;
            }
        }

        public bool Run()
        {
            switch (loopCondition)
            {
                case LoopCondition.start:
                    Start();
                    break;
                case LoopCondition.flow:
                    Flow();
                    break;
                default:
                    break;
            }                
            if (res != null)
            {
                loopCondition = LoopCondition.flow;
                Console.WriteLine($"Result: {res.ToString()}");
            }
            Console.WriteLine("Want to continue? [Y/n]");
            char decision = Console.ReadKey().KeyChar;
            if (decision == 'Y' || decision == 'y')
            {
                Console.WriteLine();
                return true;
            }
            return false;
        }

        public static Calculator getInstance()
        {
            if (calculator == null)
            {
                calculator = new Calculator();
            }
            return calculator;
        }

        private Calculator()
        {
            Console.WriteLine("Welcome to the calculator! There are five operations you may apply: addition(+), multiplication(*), subtraction(-), division(/), and clear (C).");
        }
    }    
}