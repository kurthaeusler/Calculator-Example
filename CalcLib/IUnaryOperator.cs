namespace CalcLib
{
  public interface IUnaryOperator : IOperator
  {
    Operand Evaluate(Operand item);
  }
}