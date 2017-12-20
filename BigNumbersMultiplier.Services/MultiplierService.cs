using System;
using System.Linq;
using BigNumbersMultiplier.Entites.Entities;

namespace BigNumbersMultiplier.Services
{
    public class MultiplierService : IMultiplierService
    {
        private readonly IAdderService _adderService;

        public MultiplierService(IAdderService adderService)
        {
            _adderService = adderService;
        }

        public string Multiply(BigWholeNumber a, BigWholeNumber b)
        {
            var result = MultiplyTwoStringNumbers(a.Number, b.Number);
            return result.ToString();
        }

        public string Multiply(string a, string b)
        {
            return MultiplyTwoStringNumbers(a, b).ToString();
        }

        private void MultiplyTwoDigits(char a, char b, MultiplicationResult res)
        {
            var aNumber = (int)char.GetNumericValue(a);
            var bNumber = (int)char.GetNumericValue(b);

            if (res == null)
            {
                // First result
                res = new MultiplicationResult();
            }

            var result = aNumber * bNumber + res.CarryInDigit;
            if (result < 10)
            {
                res.CarryInDigit = 0;
                res.Result = res.Result.Insert(0, result.ToString());
            }
            else
            {
                res.CarryInDigit = result/10;
                res.Result = res.Result.Insert(0, (result % 10).ToString());
            }
        }

        private MultiplicationResult MultiplyTwoStringNumbers(string a, string b)
        {
            var result = new MultiplicationResult();

            var first = a.Length >= b.Length ? a : b;
            var second = a.Length >= b.Length ? b : a;

            var addResult = "0";

            for (var i = second.Length - 1; i >= 0; i--)
            {
                for (var j = first.Length - 1; j >= 0; j--)
                {
                    MultiplyTwoDigits(second[i], first[j], result);
                }

                var trailingZeros = new string('0', second.Length - 1 - i);
                var tmpMulResult = $"{result}{trailingZeros}";

                addResult = _adderService.Add(addResult, tmpMulResult);
                result.Reset();
            }

            result.Result = addResult;
            
            return result;
        }
    }
}