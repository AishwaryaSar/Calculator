using CalculatorLibrary;

namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            String quitapp = "n";
            //display title as the c# console calculator app
            Console.WriteLine("Calculator App\r");
            Console.WriteLine("\n");
            Calculator calculator = new Calculator();
            while (quitapp == "n")
            {
                //variables used for calculation
                string inputNum1 = "";
                string inputNum2 = "";
                double result = 0;

                // Ask the user to choose an option
                Console.WriteLine("Choose an option from the following list");
                Console.WriteLine("\ta - add");
                Console.WriteLine("\ts - subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - divide");
                Console.WriteLine("Your option?");
                string inputOp = Console.ReadLine();

                //get first number
                Console.WriteLine("Type a number and then press Enter");
                inputNum1 = Console.ReadLine();

                double validInput1 = 0;
                //ensure that it is a valid input
                while (!double.TryParse(inputNum1, out validInput1))
                {
                    Console.WriteLine("please enter valid input");
                    inputNum1 = Console.ReadLine();
                }

                //get second number
                Console.WriteLine("Type the next number and then press Enter");
                inputNum2 = Console.ReadLine();

                double validInput2 = 0;
                //ensure that it is a valid input
                while (inputNum2 == "0" && inputOp == "d")
                {
                    Console.WriteLine("Division by zero is not possible. Enter a non-zero number");
                    inputNum2 = Console.ReadLine();
                }
                while (!double.TryParse(inputNum2, out validInput2))
                {
                    Console.WriteLine("please enter valid input");
                    inputNum2 = Console.ReadLine();
                }


                //perform calculator operation
                try
                {
                    calculator.calculation(validInput1, validInput2, inputOp);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception!" + ex.Message);
                }

                Console.WriteLine("Do you want to quit the calculator app? (y/n)");
                quitapp = Console.ReadLine();
            }
            //close json writer function
            calculator.Finish();
            return;
        }
    }
}



