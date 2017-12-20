namespace BigNumbersMultiplier.Entites.Entities
{
    public class MultiplicationResult
    {
        public MultiplicationResult()
        {
            Result = "";
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

        public void Reset()
        {
            Result = "";
            CarryInDigit = 0;
        }
    }
}