namespace CalcLib
{
  public class DecimalDisplayFormatter : IBaseFormatter
  {
    public string Display(decimal value)
    {
      return value.ToString();
    }
  }
}