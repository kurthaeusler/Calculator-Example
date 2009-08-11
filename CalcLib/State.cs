using System;
using System.Collections.Generic;

namespace CalcLib
{
  public abstract class State
  {
    public Stack<IStackItem> Stack // Should be protected somehow.
    { get; protected set; }

    public decimal Value { get; protected set; } // Should probably be renamed display value and become a string.

    public abstract State Digit(int digit);
    public abstract State Plus();
    public abstract State Minus();
    public abstract State Equals();
    public abstract State ClearEntry();
    public abstract State Times();
    public abstract State Divide();
    public abstract State Point();

    protected State DetermineCurrentState(State oldState)
    {
      if (Stack.Count == 0)
        return new EmptyState();
      if (Stack.Peek() is Operand)
        return new OperandOnTopState(oldState);
      if (Stack.Peek() is IUnaryOperator)
        return new UnaryOperatorOnTopState(oldState);
      if (Stack.Peek() is IBinaryOperator)
        return new BinaryOperatorOnTopState(oldState);
      throw new Exception("Stack in strange state");
    }
  }
}