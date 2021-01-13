using System;
using System.Threading.Tasks;

namespace MatanProject.Services
{
    public class UserMain
    {
        public async Task Execute()
        {
            var calc = new Calculator();


            PrintOptions();

            var userOperator = GetOperator();

            string userNumberOne = string.Empty, userNumberTwo = string.Empty;

            GetNumbers(userOperator,ref userNumberOne, ref userNumberTwo);

            var result = await SendToCalculation(userOperator, userNumberOne, userNumberTwo);

            PrintResult(result);

        }

        private void PrintResult(string result)
        {
            if (result.Contains("contact IT"))
                Console.WriteLine($"{result}");
            else
                Console.WriteLine($"The result is :  {result}");
        }

        private void PrintOptions()
        {
            Console.WriteLine("What operation you want to make? [1-8]");
            Console.WriteLine("1.Addition");
            Console.WriteLine("2.Division");
            Console.WriteLine("3.Multiplication");
            Console.WriteLine("4.Power");
            Console.WriteLine("5.Substraction");
            Console.WriteLine("6.Sqrt");
            Console.WriteLine("7.Modulo");
            Console.WriteLine("8.Abs");
        }

        private int GetOperator()
        {
            var isInalidInput = true;
            int parsedInputOp = 0;

            while (isInalidInput)
            {
                var userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out parsedInputOp))
                {
                    Console.WriteLine("The input is not a number, try again");
                    continue;
                }
                if (!(parsedInputOp > 0 && parsedInputOp < 9))
                {
                    Console.WriteLine("The input is not valid number, try again");
                    continue;
                }

                isInalidInput = false;
            }

            return parsedInputOp;
        }

        private void GetNumbers(int userOperator, ref string num1, ref string  num2)
        {
            Console.WriteLine("Choose first number");
            num1 = GetNumber();

            if (!(userOperator == 6 || userOperator == 8))
            {
                Console.WriteLine("Choose Second number");
                num2 = GetNumber();
            }     
        }

        private async Task<string> SendToCalculation(int op, string numberOne, string numberTwo)
        {
            var calc = new Calculator();
            string result = string.Empty;

            switch (op)
            {
                case 1:                  
                        result = await calc.Addition(numberOne, numberTwo);
                        break;               
                case 2:                  
                        result = await calc.Division(numberOne, numberTwo);
                        break;               
                case 3:               
                        result = await calc.Multiplication(numberOne, numberTwo);
                        break;                 
                case 4:              
                        result = await calc.Power(numberOne, numberTwo);
                        break;              
                case 5:                
                        result = await calc.Substraction(numberOne, numberTwo);
                        break;                
                case 6:             
                        result = await calc.Sqrt(numberOne);
                        break;                
                case 7:                
                        result = await calc.Modulo(numberOne, numberTwo);
                        break;                  
                case 8:                   
                        result = await calc.Abs(numberOne);
                        break;                    
                default:
                    break;
            }
            return result;
        }

        private string GetNumber()
        {
            var isInalidInput = true;
            string returnNumber = string.Empty;

            while (isInalidInput)
            {
                returnNumber = Console.ReadLine();
                int parsedNumberOne;

                if (!int.TryParse(returnNumber, out parsedNumberOne))
                {
                    Console.WriteLine("The input is not a number, try again");
                    continue;
                }
                isInalidInput = false;
            }
            return returnNumber;
        }
    }
}
