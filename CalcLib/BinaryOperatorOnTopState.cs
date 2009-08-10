namespace CalcLib
{
  public class BinaryOperatorOnTopState : State
  {
    public BinaryOperatorOnTopState(State state)
    {
      Value = state.Value;
      Stack = state.Stack;
    }

    public override State Digit(int digit)
    {
      Stack.Push(new Operand(digit));
      return new OperandOnTopState(this);
    }

    public override State Minus()
    {
      Stack.Push(new Negate());
      return new UnaryOperatorOnTopState(this);
    }

    public override State Plus()
    {
      Stack.Push(new Plus());
      return new BinaryOperatorOnTopState(this);
    }

    public override State Equals()
    {
      return this;
    }

    public override State ClearEntry()
    {
      // Dont change the stack, just set the value to 0.
      Value = 0;
      return this;
    }

    public override State Times()
    {
      Stack.Pop(); // Throw away
      Stack.Push(new Multiplication());
      return this;
    }

    public override State Divide()
    {
      Stack.Pop(); // Throw away
      Stack.Push(new Division());
      return this;
    }

    public override State Point()
    {
      Stack.Push(new DecimalPoint());
      return new DecimalPointOnTopState(this);
    }
  }
}