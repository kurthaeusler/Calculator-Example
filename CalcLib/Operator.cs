
using System;

namespace CalcLib
{	
	public interface Operator : StackItem
	{
		Operand Evaluate(Operand item1, Operand item2);
	}
}
