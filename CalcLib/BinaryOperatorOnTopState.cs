namespace CalcLib
{
    public class BinaryOperatorOnTopState : State
    {
        private int _value;

        public BinaryOperatorOnTopState(State state)
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
            // Dont change the stack, just set the value to 0.
            _value = 0;
            return this;
        }
    }
}