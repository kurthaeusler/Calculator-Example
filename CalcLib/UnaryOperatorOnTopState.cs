namespace CalcLib
{
  public class UnaryOperatorOnTopState : State
  {
    public UnaryOperatorOnTopState(State state)
    {
      Value = state.Value;
      Stack = state.Stack;
    }

    public override State Digit(int digit)
    {
      Stack.Push(((IUnaryOperator) Stack.Pop()).Evaluate(new Operand(digit)));
      return new OperandOnTopState(this);
    }

    public override State Minus()
    {
      // Throw away existing op
      Stack.Pop();
      Stack.Push(new Negate()); // Seems to be what most calcs do.
      return this;
    }

    public override State Plus()
    {
      Stack.Pop();
      Stack.Push(new Plus());
      return new BinaryOperatorOnTopState(this);
    }

    public override State Equals()
    {
      return this;
    }

    public override State ClearEntry()
    {
      Stack.Pop(); // throw away
      Value = 0;
      return DetermineCurrentState(this);
    }

    public override State Times()
    {
      Stack.Pop(); // Throw away
      Stack.Push(new Multiplication());
      return new BinaryOperatorOnTopState(this);
    }

    public override State Divide()
    {
      Stack.Pop(); // Throw away
      Stack.Push(new Division());
      return new BinaryOperatorOnTopState(this);
    }

    public override State Point()
    {
      Stack.Push(new DecimalPoint());
      return new DecimalPointOnTopState(this);
    }
  }
}