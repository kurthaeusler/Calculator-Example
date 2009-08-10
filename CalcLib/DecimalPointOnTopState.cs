using System;

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
      throw new NotImplementedException();
    }

    public override State Plus()
    {
      throw new NotImplementedException();
    }

    public override State Minus()
    {
      throw new NotImplementedException();
    }

    public override State Equals()
    {
      throw new NotImplementedException();
    }

    public override State ClearEntry()
    {
      throw new NotImplementedException();
    }

    public override State Times()
    {
      throw new NotImplementedException();
    }

    public override State Divide()
    {
      throw new NotImplementedException();
    }

    public override State Point()
    {
      return this;
    }
  }
}