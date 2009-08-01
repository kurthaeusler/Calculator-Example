namespace CalcLib
{
  public class Negate : IUnaryOperator
  {
    #region IUnaryOperator Members

    public Operand Evaluate(Operand item)
    {
      return new Operand(item.Value*-1);
    }

    #endregion
  }
}