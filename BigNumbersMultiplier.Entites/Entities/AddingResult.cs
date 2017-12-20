namespace BigNumbersMultiplier.Entites.Entities
{
    public class AddingResult
    {
        public AddingResult()
        {
            Result = "";
            CarryInDigit = 0;
        }
        public string Result { get; set; }
        public int CarryInDigit { get; set; }

        public override string ToString()
        {
            if (CarryInDigit == 0)
            {
                return Result;
            }
            return $"{CarryInDigit}{Result}";
        }
    }
}