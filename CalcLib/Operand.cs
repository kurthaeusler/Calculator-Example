namespace CalcLib
{
    public class Operand : IStackItem
    {
        private readonly int _value;

        public Operand(int val)
        {
            _value = val;
        }

        public int Value
        {
            get { return _value; }
        }

        public Operand AppendDigit(int val)
        {
            return new Operand(_value > -1 ? _value*10 + val : _value*10 - val);
        }

        public static Operand operator +(Operand item1, Operand item2)
        {
            return new Operand(item1._value + item2._value);
        }

        public static Operand operator -(Operand item1, Operand item2)
        {
            return new Operand(item1._value - item2._value);
        }
    }
}