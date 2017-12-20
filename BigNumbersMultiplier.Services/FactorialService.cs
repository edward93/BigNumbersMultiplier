using System.Threading.Tasks;

namespace BigNumbersMultiplier.Services
{
    public class FactorialService : IFactorialService
    {
        private readonly IMultiplierService _multiplierService;

        public FactorialService(IMultiplierService multiplierService)
        {
            _multiplierService = multiplierService;
        }

        public string Calculate(int number)
        {
            var factorialResult = "1";
            Parallel.For(1, number, i =>
            {
                factorialResult = _multiplierService.Multiply(factorialResult, i.ToString());
            });

            return factorialResult;
        }
    }
}