namespace CalcLib
{
  public class Operand : IStackItem
  {
    private readonly decimal _value;

    public Operand(decimal val)
    {
      _value = val;
    }

    public decimal Value
    {
      get { return _value; }
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
  }
}