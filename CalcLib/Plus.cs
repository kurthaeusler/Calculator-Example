namespace CalcLib
{
  public class Plus : IBinaryOperator
  {
    public Operand Evaluate(Operand item1, Operand item2)
    {
      return item1 + item2;
    }
  }
}