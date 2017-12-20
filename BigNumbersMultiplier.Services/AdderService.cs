using BigNumbersMultiplier.Entites.Entities;

namespace BigNumbersMultiplier.Services
{
    public class AdderService : IAdderService
    {
        public string Add(BigWholeNumber a, BigWholeNumber b)
        {
            var result = AddTwoStringNumbers(a.Number, b.Number);
            return result.ToString();
        }

        public string Add(string a, string b)
        {
            // equalize the values in terms of length
            if (a.Length > b.Length)
            {
                b = b.Insert(0, new string('0', a.Length - b.Length));
            }
            else if (a.Length < b.Length)
            {
                a = a.Insert(0, new string('0', b.Length - a.Length));
            }
            return AddTwoStringNumbers(a, b).ToString();
        }

        private void AddTwoDigits(char a, char b, AddingResult res)
        {
            var aNumber = (int)char.GetNumericValue(a);
            var bNumber = (int)char.GetNumericValue(b);
            if (res == null)
            {
                // First result
                res = new AddingResult();
            }
            var result = aNumber + bNumber + res.CarryInDigit;
            if (result < 10)
            {
                res.CarryInDigit = 0;
                res.Result = res.Result.Insert(0, result.ToString());
            }
            else
            {
                res.CarryInDigit = 1;
                res.Result = res.Result.Insert(0, (result - 10).ToString());
            }
        }

        private AddingResult AddTwoStringNumbers(string a, string b)
        {
            // equalize the values in terms of length
            if (a.Length > b.Length)
            {
                b = b.Insert(0, new string('0', a.Length - b.Length));
            }
            else if (a.Length < b.Length)
            {
                a = a.Insert(0, new string('0', b.Length - a.Length));
            }
            var result = new AddingResult();
            for (int i = a.Length - 1; i >= 0; i--)
            {
                AddTwoDigits(a[i], b[i], result);
            }

            return result;
        }
    }
}