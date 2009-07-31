
using System;

namespace CalcLib
{
	
	
	public class Operand : StackItem
	{
		int _value;
		
		public int Value
		{
			get { return _value; }
		}
		
		public Operand(int val)
		{
			_value = val;
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
