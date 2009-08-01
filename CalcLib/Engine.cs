namespace CalcLib
{
    public class Engine
    {
        private State _state;

        public Engine()
        {
            _state = new EmptyState();
        }

        public int Value
        {
            get { return _state.Value; }
        }

        public void Number(int number)
        {
            _state = _state.Number(number);
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
    }
}