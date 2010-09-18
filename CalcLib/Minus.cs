namespace CalcLib
{
  public class Minus : IBinaryOperator
  {
    public Operand Evaluate(Operand item1, Operand item2)
    {
      return item1 - item2;
    }
  }
}