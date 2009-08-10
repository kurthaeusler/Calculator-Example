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
  }
}