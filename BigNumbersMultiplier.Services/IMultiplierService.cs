using BigNumbersMultiplier.Entites.Entities;

namespace BigNumbersMultiplier.Services
{
    public interface IMultiplierService
    {
        string Multiply(BigWholeNumber a, BigWholeNumber b);
        string Multiply(string a, string b);
    }
}