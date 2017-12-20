using System;
using System.Threading.Tasks;
using BigNumbersMultiplier.Entites.Entities;
using BigNumbersMultiplier.Services;

namespace BigNumbersMultiplier.Controller
{
    public class MainController
    {
        private readonly IAdderService _adderService;
        private readonly IMultiplierService _multiplierService;
        private readonly IFactorialService _factorialService;

        public MainController(IAdderService adderService, IMultiplierService multiplierService, IFactorialService factorialService)
        {
            _adderService = adderService;
            _multiplierService = multiplierService;
            _factorialService = factorialService;
        }

        public async Task Run(string[] args)
        {
            Console.WriteLine($"Enter number to calculate factorial (0 < X < {int.MaxValue})");
            var first = Console.ReadLine();
            int.TryParse(first, out var number);
            if (number == 0)
            {
                Console.WriteLine($"Please enter valid number (0 < X < {int.MaxValue})");
                return;
            }
            Console.WriteLine($"Calculating {first}! ... this might take some time");

            var result = _factorialService.Calculate(number);

            Console.WriteLine($"Result is: {result}");
        }
    }
}