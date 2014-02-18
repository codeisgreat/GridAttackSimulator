namespace GridAttackSimulator
{
    public class EnvironmentPosition
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public EnvironmentPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}