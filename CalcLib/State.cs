using System.Collections.Generic;

namespace CalcLib
{
    public abstract class State
    {
        public abstract int Value { get; }

        public Stack<IStackItem> Stack // Should be protected somehow.
        { get; protected set; }

        public abstract State Number(int number);

        public abstract State Plus();

        public abstract State Minus();

        public abstract State Equals();
    }
}