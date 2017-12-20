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
            for (int i = 1; i <= number; i++)
            {
                factorialResult = _multiplierService.Multiply(factorialResult, i.ToString());
            }

            return factorialResult;
        }
    }
}