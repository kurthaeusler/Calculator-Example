using System;

namespace CalcLib
{
  public class OperandOnTopState : State
  {
    private decimal _value;

    public OperandOnTopState(State state)
    {
      Stack = state.Stack;
      _value = ((Operand) Stack.Peek()).Value;
    }

    public override decimal Value
    {
      get { return _value; }
    }

    public override State Digit(int digit)
    {
      Operand newOperand = ((Operand) Stack.Pop()).AppendDigit(digit);
      _value = newOperand.Value;
      Stack.Push(newOperand);
      return this;
    }

    public override State Minus()
    {
      if (Stack.Count > 2)
      {
        Evaluate();
      }
      Stack.Push(new Minus());
      return new BinaryOperatorOnTopState(this);
    }

    private void Evaluate()
    {
      // Depends if we have only an operand, or an operand/operator/operand.
      if (Stack.Count < 3) return;
      // This should be two separate states.
      var item2 = (Operand) Stack.Pop();
      var op = (IBinaryOperator) Stack.Pop();
      var item1 = (Operand) Stack.Pop();
      Operand val = op.Evaluate(item1, item2);
      Stack.Push(val);
      _value = val.Value;
    }

    public override State Plus()
    {
      if (Stack.Count > 2)
      {
        Evaluate();
      }
      // Could possibly be 2 states
      Stack.Push(new Plus());
      return new BinaryOperatorOnTopState(this);
    }

    public override State Equals()
    {
      Evaluate();
      return this;
    }

    public override State ClearEntry()
    {
      Stack.Pop(); // Throw it away
      _value = 0;
      if (Stack.Count == 0)
        return new EmptyState();
      if (Stack.Peek() is IBinaryOperator)
        return new BinaryOperatorOnTopState(this);
      if (Stack.Peek() is Operand)
        return new OperandOnTopState(this);
      // We shouldn't see a unary operator on the top
      throw new Exception("Stack in strange state");
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
  }
}