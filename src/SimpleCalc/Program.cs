using System;

namespace SimpleCalc
{
    class SimpleCalc
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("**********************************************");
            Console.WriteLine("************** SIMPLE CALCULATOR *************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("\nPlease, type the mathematical expression with only 2 (!!) arguments");
            Console.WriteLine("The following math operators are supported: '+', '-', '/', '*'");
            Console.WriteLine("Type 'q' for exit, and 'h' for help");
            Console.WriteLine("Good luck, Amigo!\n");


            Console.WriteLine("----------------- CALCULATOR -----------------");
            while (true)
            {
                Console.Write("User input: ");
                string UserInput = Console.ReadLine();

                switch (UserInput)
                {
                    // Quite calculator
                    case "q":
                        return;

                    // Show help message
                    case "h":
                        PrintHelpMessageToConsole();
                        break;

                    // Perform calculations
                    default:
                        Calculate(UserInput);
                        break;
                }
            }
        }


        // Calculation function performs the basic math operations (+, -, *, /)
        // with only 2 (!!) arguments 
        public static void Calculate(string mathExpression)
        {

            // Parse string to find the available math operators.
            // Stop processing if `mathExpression` does not contain math operators.
            char[] mathOperators = { '+', '-', '*', '/' };

            if (!ExpressionContainsMathOperators(mathExpression, mathOperators))
            {
                //Console.WriteLine("There is no available math operators in expression!");
                Console.WriteLine($"Output: {mathExpression} \n");
                return;
            }


            // Check the number of arguments in math expression.
            // Continue calculations, when number_of_argments = [ARG_NUM_MIN; ARG_NUM_MAX]
            string[] arguments = mathExpression.Split(mathOperators);
            const int ARG_NUM_MAX = 2;
            const int ARG_NUM_MIN = 1;

            if (arguments.Length > ARG_NUM_MAX)
            {
                Console.WriteLine($"Too many arguments ({arguments.Length}) for calculations. The max available number of arguments is {ARG_NUM_MAX}");
                return;
            }
            else if (arguments.Length < ARG_NUM_MIN)
            {
                Console.WriteLine($"Too few arguments ({arguments.Length}) for calculations. The min available number of arguments is {ARG_NUM_MIN}");
                return;
            }



            // Parse string fragments and convert they to double data type
            double[] numbers = new double[2];
            bool invalidArgs = false;
            for (int i = 0; i < arguments.Length; i++)
            {
                try
                {
                    //double.TryParse(arguments[i], out numbers[i]);
                    numbers[i] = double.Parse(arguments[i]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Argument [{0}] is not numeric or empty! Try again...", i);
                    invalidArgs = true;
                }
            }

            // Abort calculations, when at least one of the arguments has an
            // invalid data type
            if (invalidArgs)
                return;


            // Perform calculations (choose the correct math function)
            foreach (char op in mathOperators)
            {
                string output;
                if (mathExpression.Contains(op.ToString()))
                {
                    switch (op)
                    {
                        case '+':
                            output = Sum(numbers[0], numbers[1]).ToString();
                            break;

                        case '-':
                            output = Difference(numbers[0], numbers[1]).ToString();
                            break;

                        case '*':
                            output = Mulitplication(numbers[0], numbers[1]).ToString();
                            break;

                        case '/':
                            output = Division(numbers[0], numbers[1]).ToString();
                            break;

                        default:
                            Console.WriteLine("Unknown math operation {0}! Try again...", op);
                            output = "null";
                            break;
                    }

                    Console.WriteLine($"Output: {output}\n");
                    return; // Only one calculation is available (break calculations)
                }
            }


        }

        // Check, if there are some mathematical operators in mathematical expression
        public static bool ExpressionContainsMathOperators(string mathExpression, char[] mathOperators)
        {

            foreach (char d in mathOperators)
            {
                if (mathExpression.Contains(d.ToString()))
                    return true;
                else
                    continue;
            }

            return false;
        }

        public static void PrintHelpMessageToConsole()
        {
            Console.WriteLine("------------------ HELP ---------------------");
            Console.WriteLine("The following operators are available:");
            Console.WriteLine("     '+' -- sum, e.g. 5 + 4");
            Console.WriteLine("     '-' -- difference, e.g. 5 - 4");
            Console.WriteLine("     '*' -- multiplication, e.g. 5 * 4");
            Console.WriteLine("     '/' -- division, e.g. 5 / 4");
            Console.WriteLine("/n'q' -- quite calculator\n");

        }

        public static double Sum(double a, double b) => a + b;

        public static double Difference(double a, double b) => a - b;

        public static double Mulitplication(double a, double b) => a * b;

        public static double Division(double a, double b)
        {
            if (b == 0)
                Console.WriteLine("Division by 0 is detected! The result may be wrong!");

            return a / b;
        }

    }
}
