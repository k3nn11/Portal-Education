using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validation
{
    public class ValidationService : IValidationService
    {
        public char OptionValidation(string material)
        {
            Console.WriteLine($"Would you like to add more {material} materials: Y/N");
            while (true)
            {
                bool isValid = char.TryParse(Console.ReadLine().ToUpper(), out char input);
                if (isValid)
                {
                    if (input != 'Y' && input != 'N')
                    {
                        Console.WriteLine("Enter valid input Y/N");
                        continue;
                    }
                    else if (input == 'Y')
                    {
                        return input;
                    }
                    else if (input == 'N')
                    {
                        return input;
                    }
                }
                else
                {
                    Console.WriteLine("Enter valid input: Y/N");
                    continue;
                }
            }
        }

        public DateTime ValidationDate()
        {
            Console.WriteLine("Enter a date and time (yyyy-MM-dd):");
            while (true)
            {
                string userInput = Console.ReadLine();

                if (DateTime.TryParse(userInput, out DateTime dateTime))
                {
                    //Console.WriteLine("Valid DateTime: " + dateTime.ToString("yyyy-MM-dd"));
                    return dateTime;
                }
                else
                {
                    Console.WriteLine("Invalid DateTime format: (yyyy-MM-dd)");
                    continue;
                }
            }
        }

        public decimal ValidationDecimal()
        {
            Console.WriteLine("Enter a decimal number:");
            while (true)
            {
                string userInput = Console.ReadLine();

                if (decimal.TryParse(userInput, out decimal number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Invalid decimal number");
                    continue;
                }
            }
        }

        public int ValidationInterger()
        {
            while (true)
            {
                Console.WriteLine("Enter an integer number:");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Invalid integer number");
                    continue;
                }
            }
        }
    }
}
