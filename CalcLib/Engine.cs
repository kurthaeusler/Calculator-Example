
using System.Collections.Generic;

namespace CalcLib
{	
	public class Engine
	{
		private Stack<StackItem>  _stack;
		private int _value;
		
		public int Value
		{
			get {return _value;}
		}
		
		public Engine()
		{
			_stack = new Stack<StackItem>();
		}
		
		public void Number(int number)
		{
			_stack.Push(new Operand(number));
		}
		
		public void Plus()
		{
			_stack.Push(new Plus());
			if(_stack.Count > 3)
				UpdateValue();
		}
		
		public void Minus()
		{
			_stack.Push(new Minus());
			if(_stack.Count > 3)
				UpdateValue();
		}
		
		public void Equals()
		{
			Evaluate();
			_value = ((Operand)_stack.Peek()).Value;
		}
		
		private void UpdateValue()
		{
			Operator lastOp = (Operator)_stack.Pop();
			Equals();
			_stack.Push(lastOp);
		}
		
		private void Evaluate()
		{
			Operand item2 = (Operand)_stack.Pop();
			Operator op = (Operator)_stack.Pop();
			Operand item1 = (Operand)_stack.Pop();
			Operand val = op.Evaluate(item1, item2);
			_stack.Push(val);
		}
	}
}
