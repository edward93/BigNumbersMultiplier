using BigNumbersMultiplier.Entites.Entities;

namespace BigNumbersMultiplier.Services
{
    public interface IAdderService
    {
        string Add(BigWholeNumber a, BigWholeNumber b);
        string Add(string a, string b);
    }
}