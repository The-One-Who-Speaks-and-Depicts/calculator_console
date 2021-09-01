using System;

namespace calculator_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = Calculator.getInstance();
            calc.Run();
        }
    }
}
