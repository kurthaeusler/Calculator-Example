using System.Collections.Generic;

namespace CalcLib
{
    public class Engine
    {
        private readonly Stack<IStackItem> _stack;
        private int _value;

        public Engine()
        {
            _stack = new Stack<IStackItem>();
        }

        public int Value
        {
            get { return _value; }
        }

        public void Number(int number)
        {
            _stack.Push(new Operand(number));
        }

        public void Plus()
        {
            _stack.Push(new Plus());
            if (_stack.Count > 3)
                UpdateValue();
        }

        public void Minus()
        {
            _stack.Push(new Minus());
            if (_stack.Count > 3)
                UpdateValue();
        }

        public void Equals()
        {
            Evaluate();
            _value = ((Operand) _stack.Peek()).Value;
        }

        private void UpdateValue()
        {
            var lastOp = (IOperator) _stack.Pop();
            Equals();
            _stack.Push(lastOp);
        }

        private void Evaluate()
        {
            var item2 = (Operand) _stack.Pop();
            var op = (IOperator) _stack.Pop();
            var item1 = (Operand) _stack.Pop();
            Operand val = op.Evaluate(item1, item2);
            _stack.Push(val);
        }
    }
}