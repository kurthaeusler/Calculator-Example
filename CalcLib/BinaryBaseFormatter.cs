using System;

namespace CalcLib
{
  public class BinaryBaseFormatter : IBaseFormatter
  {
    public string Display(decimal value)
    {
      return Convert.ToString((long) value, 2);
    }
  }
}