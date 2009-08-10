using System;

namespace CalcLib
{
  public class Operand : IStackItem
  {
    private readonly decimal _value;
    private int _currentDecimalPlace;

    public Operand(decimal val)
    {
      _value = val;
      _currentDecimalPlace = 0;
    }

    public decimal Value
    {
      get { return _value; }
    }

    public bool IsDigit
    {
      get
      {
        return Value > -1 &&
               Value < 10 &&
               Value == Math.Truncate(Value);
      }
    }

    public Operand AppendDigit(int digit)
    {
      return new Operand(_value > -1 ? _value*10 + digit : _value*10 - digit);
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
      _currentDecimalPlace++;
      return new Operand(_value + (decimal) (digit*Math.Pow(10, _currentDecimalPlace*-1)));
    }
  }
}