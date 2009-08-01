namespace CalcLib
{
    public class UnaryOperatorOnTopState : State
    {
        private readonly int _value;

        public UnaryOperatorOnTopState(State state)
        {
            _value = state.Value;
            Stack = state.Stack;
        }

        public override int Value
        {
            get { return _value; }
        }

        public override State Number(int number)
        {
            Stack.Push(((IUnaryOperator) Stack.Pop()).Evaluate(new Operand(number)));
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
            Stack.Push(new Plus());
            return new BinaryOperatorOnTopState(this);
        }

        public override State Equals()
        {
            return this;
        }
    }
}