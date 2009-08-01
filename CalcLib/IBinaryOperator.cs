namespace CalcLib
{
  public interface IBinaryOperator : IOperator
  {
    Operand Evaluate(Operand item1, Operand item2);
  }
}