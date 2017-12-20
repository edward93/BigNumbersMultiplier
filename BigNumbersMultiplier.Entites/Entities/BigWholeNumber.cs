namespace BigNumbersMultiplier.Entites.Entities
{
    public class BigWholeNumber
    {
        public BigWholeNumber()
        {
            Number = "0";
        }
        public BigWholeNumber(long number)
        {
            Number = number.ToString();
        }

        public BigWholeNumber(string nummber)
        {
            Number = nummber;
        }

        public string Number { get; set; }
    }
}