using System.Threading.Tasks;

namespace MatanProject.Services
{
    public class Calculator
    {
        public async Task<string> Addition(string num1, string num2)
        {
            return await new MicroservocesManager().CalculateAsync("Addition", num1, num2);
        }

        public async Task<string> Division(string num1, string num2)
        {
            return await new MicroservocesManager().CalculateAsync("Division", num1, num2);
        }

        public async Task<string> Multiplication(string num1, string num2)
        {
            return await new MicroservocesManager().CalculateAsync("Multiplication", num1, num2);
        }

        public async Task<string> Power(string num1, string num2)
        {
            return await new MicroservocesManager().CalculateAsync("Power", num1, num2);
        }

        public async Task<string> Substraction(string num1, string num2)
        {
            return await new MicroservocesManager().CalculateAsync("Substraction", num1, num2);
        }
        public async Task<string> Sqrt(string num1)
        {
            return await new MicroservocesManager().CalculateAsync("Sqrt", num1);
        }
        public async Task<string> Modulo(string num1, string num2)
        {
            return await new MicroservocesManager().CalculateAsync("Modulo", num1, num2);
        }
        public async Task<string> Abs(string num1)
        {
            return await new MicroservocesManager().CalculateAsync("Abs", num1);
        }
    }
}