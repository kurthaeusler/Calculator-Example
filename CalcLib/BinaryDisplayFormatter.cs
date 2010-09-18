using System;

namespace CalcLib
{
  public class BinaryDisplayFormatter : IBaseFormatter
  {
    public string Display(decimal value)
    {
      return Convert.ToString((long) value, 2);
    }
  }
}