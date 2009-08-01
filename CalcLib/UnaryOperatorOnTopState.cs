using System;

namespace CalcLib
{
  public class UnaryOperatorOnTopState : State
  {
    private decimal _value;

    public UnaryOperatorOnTopState(State state)
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
      _value = 0;
      if (Stack.Count == 0)
        return new EmptyState();
      if (Stack.Peek() is IBinaryOperator)
        return new BinaryOperatorOnTopState(this);
      if (Stack.Peek() is Operand)
        return new OperandOnTopState(this);
      throw new Exception("Stack in strange state");
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
  }
}