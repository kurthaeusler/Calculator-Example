namespace CalcLib
{
  public class Engine
  {
    private State _state;

    public Engine()
    {
      _state = new EmptyState();
    }

    public decimal Value
    {
      get { return _state.Value; }
    }

    public string Display
    {
      get { return _state.Display; }
    }

    public void Digit(int digit)
    {
      _state = _state.Digit(digit);
    }

    public void Plus()
    {
      _state = _state.Plus();
    }

    public void Minus()
    {
      _state = _state.Minus();
    }

    public void Equals()
    {
      _state = _state.Equals();
    }

    public void ClearEntry()
    {
      _state = _state.ClearEntry();
    }

    public void ClearAll()
    {
      _state = new EmptyState();
    }

    public void Times()
    {
      _state = _state.Times();
    }

    public void Divide()
    {
      _state = _state.Divide();
    }

    public void Point()
    {
      _state = _state.Point();
    }

    public void Binary()
    {
      _state = _state.Binary();
    }
  }
}