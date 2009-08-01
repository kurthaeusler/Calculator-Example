namespace CalcLib
{
  public class BinaryOperatorOnTopState : State
  {
    private decimal _value;

    public BinaryOperatorOnTopState(State state)
    {
      _value = state.Value;
      Stack = state.Stack;
    }

    public override decimal Value
    {
      get { return _value; }
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
      _value = 0;
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
  }
}