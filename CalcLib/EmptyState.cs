using System.Collections.Generic;

namespace CalcLib
{
    public class EmptyState : State
    {
        public EmptyState()
        {
            Stack = new Stack<IStackItem>();
        }

        public override int Value
        {
            get { return 0; }
        }

        public override State Number(int number)
        {
            Stack.Push(new Operand(number));
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
    }
}