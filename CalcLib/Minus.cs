namespace CalcLib
{
    public class Minus : IOperator
    {
        #region IOperator Members

        public Operand Evaluate(Operand item1, Operand item2)
        {
            return item1 - item2;
        }

        #endregion
    }
}