namespace CalcLib
{
  public class Negate : IUnaryOperator
  {
    public Operand Evaluate(Operand item)
    {
      return new Operand(item.Value*-1);
    }
  }
}