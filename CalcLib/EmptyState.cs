using System.Collections.Generic;

namespace CalcLib
{
  public class EmptyState : State
  {
    public EmptyState()
    {
      Stack = new Stack<IStackItem>();
      Value = 0;
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
      return this;
    }

    public override State Times()
    {
      Stack.Push(new Multiplication());
      return new BinaryOperatorOnTopState(this);
    }

    public override State Divide()
    {
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