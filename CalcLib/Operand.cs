using System;

namespace CalcLib
{
  public class Operand : IStackItem
  {
    private readonly int _currentDecimalPlace;
    private readonly decimal _value;

    public Operand(decimal val)
    {
      _value = val;
      _currentDecimalPlace = 0;
    }

    private Operand(decimal val, int currentDecimalPlace)
    {
      _value = val;
      _currentDecimalPlace = currentDecimalPlace;
    }

    public decimal Value
    {
      get { return _value; }
    }

    public Operand AppendDigit(int digit)
    {
      return _currentDecimalPlace > 0
               ? AppendDecimalIncrement(digit)
               : new Operand(_value > -1
                               ? _value*10 + digit
                               : _value*10 - digit);
    }

    public static Operand operator +(Operand item1, Operand item2)
    {
      return new Operand(item1._value + item2._value);
    }

    public static Operand operator -(Operand item1, Operand item2)
    {
      return new Operand(item1._value - item2._value);
    }

    public static Operand operator *(Operand item1, Operand item2)
    {
      return new Operand(item1._value*item2._value);
    }

    public static Operand operator /(Operand item1, Operand item2)
    {
      return new Operand(item1._value/item2._value);
    }

    public Operand AppendDecimalIncrement(int digit)
    {
      if (_value < 0)
        digit = digit*-1;
      return new Operand(_value + (decimal) (digit*Math.Pow(10, (_currentDecimalPlace + 1)*-1)),
                         _currentDecimalPlace + 1);
    }
  }
}