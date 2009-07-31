namespace CalcLib
{
    public interface IOperator : IStackItem
    {
        Operand Evaluate(Operand item1, Operand item2);
    }
}