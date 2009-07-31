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
            Operand newOperand;
            if (_stack.Count > 0 && _stack.Peek() is IUnaryOperator)
                newOperand = ((IUnaryOperator) _stack.Pop()).Evaluate(new Operand(number));
            else if (_stack.Count > 0 && _stack.Peek() is Operand)
                newOperand = ((Operand) _stack.Peek()).AppendDigit(number);
            else
                newOperand = new Operand(number);
            _stack.Push(newOperand);
            UpdateValue();
        }

        public void Plus()
        {
            _stack.Push(new Plus());
            UpdateValue();
        }

        public void Minus()
        {
            if (_stack.Count == 0 || _stack.Peek() is IOperator)
                _stack.Push(new Negate());
            else
                _stack.Push(new Minus());
            UpdateValue();
        }

        public void Equals()
        {
            Evaluate();
        }

        private void UpdateValue()
        {
            if (_stack.Count < 4)
            {
                if (_stack.Peek() is Operand)
                    _value = ((Operand) _stack.Peek()).Value;
                return;
            }
            var lastOp = (IOperator) _stack.Pop();
            Evaluate();
            _stack.Push(lastOp);
        }

        private void Evaluate()
        {
            var item2 = (Operand) _stack.Pop();
            var op = (IBinaryOperator) _stack.Pop();
            var item1 = (Operand) _stack.Pop();
            Operand val = op.Evaluate(item1, item2);
            _stack.Push(val);
            _value = val.Value;
        }
    }
}