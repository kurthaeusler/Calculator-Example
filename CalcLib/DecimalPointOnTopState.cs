namespace CalcLib
{
  public class DecimalPointOnTopState : State
  {
    public DecimalPointOnTopState(State state)
    {
      Stack = state.Stack;
      Value = state.Value;
    }

    public override State Digit(int digit)
    {
      Stack.Pop();
      if (Stack.Peek() is Negate)
      {
        Stack.Pop();
        digit = digit*-1;
      }
      Stack.Push((Stack.Count < 1 || !(Stack.Peek() is Operand)
                    ? new Operand(0)
                    : (Operand) Stack.Pop()).AppendDecimalIncrement(digit));
      return new OperandOnTopState(this);
    }

    public override State Plus()
    {
      Stack.Pop();
      Stack.Push(new Plus());
      return new BinaryOperatorOnTopState(this);
    }

    public override State Minus()
    {
      Stack.Pop();
      Stack.Push(new Minus());
      return new BinaryOperatorOnTopState(this);
    }

    public override State Equals()
    {
      Stack.Pop();
      return DetermineCurrentState(this).Equals();
    }

    public override State ClearEntry()
    {
      Stack.Pop();
      return DetermineCurrentState(this).ClearEntry();
    }

    public override State Times()
    {
      Stack.Pop();
      Stack.Push(new Multiplication());
      return new BinaryOperatorOnTopState(this);
    }

    public override State Divide()
    {
      Stack.Pop();
      Stack.Push(new Division());
      return new BinaryOperatorOnTopState(this);
    }

    public override State Point()
    {
      return this;
    }
  }
}