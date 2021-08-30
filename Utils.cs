using System;
namespace calculator_console
{
    public static class Utils
    {
        public static decimal DecimalParse(string order)
        {
            decimal result;
            while (true)
            {
                Console.WriteLine($"Insert {order} number: ");
                string first_non_parsed = Console.ReadLine();
                if (decimal.TryParse(first_non_parsed, out result))
                {
                    break;
                }
                Console.WriteLine("Error");
            }
            return result;
        }

        public static string OperationParse()
        {
            while (true)
            {
                Console.WriteLine($"Insert operation: ");
                string operation_non_parsed = Console.ReadLine();
                switch (operation_non_parsed)
                {
                    case "+":
                    case "*":
                    case "-":
                    case "/":
                    case "C":
                        return operation_non_parsed;
                    default:
                        Console.WriteLine("Error");
                        break;
                }                
            }
        }        
    }
}