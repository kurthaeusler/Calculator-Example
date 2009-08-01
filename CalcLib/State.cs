using System.Collections.Generic;

namespace CalcLib
{
  public abstract class State
  {
    public abstract decimal Value { get; }

    public Stack<IStackItem> Stack // Should be protected somehow.
    { get; protected set; }

    public abstract State Digit(int digit);

    public abstract State Plus();

    public abstract State Minus();

    public abstract State Equals();
    public abstract State ClearEntry();
    public abstract State Times();
    public abstract State Divide();
  }
}